using QuanLyBanSach_Web.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace QuanLyBanSach_Web.Controllers
{
    public class GioHangController : Controller
    {
        KetNoi kn = new KetNoi();
        //Lấy Giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGH = Session["GioHang"] as List<GioHang>;
            if (listGH == null)
            {
                //Ktra nếu chưa tồn tại thỳ khởi tạo listGH 
                listGH = new List<GioHang>();
                Session["GioHang"] = listGH;
            }
            return listGH;
        }
        public ActionResult ThemGioHang(int MaSP, string strUrl)
        {
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session GioHang
            List<GioHang> ListGH = LayGioHang();
            GioHang SanPham = ListGH.Find(n => n.iMaSach == MaSP);
            if (SanPham == null)
            {
                SanPham = new GioHang(MaSP);
                ListGH.Add(SanPham);
                return Redirect(strUrl);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strUrl);
            }
        }
        public ActionResult CapNhap(int MaSP, FormCollection f)
        {
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> ListGH = LayGioHang();
            GioHang SanPham = ListGH.SingleOrDefault(n => n.iMaSach == MaSP);
            if (SanPham != null)
            {
                SanPham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSP);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> ListGH = LayGioHang();
            GioHang SanPham = ListGH.SingleOrDefault(n => n.iMaSach == MaSP);
            if (SanPham != null)
            {
                ListGH.RemoveAll(n => n.iMaSach == MaSP);
            }
            if (ListGH.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> ListGH = LayGioHang();
            return View(ListGH);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }
        #region Đặt hàng
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            ddh.MaKH = kh.MaKH;
            ddh.NgayDat = DateTime.Now;
            kn.DonHangs.Add(ddh);
            kn.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                ctDH.MaDH = ddh.MaDH;
                ctDH.MaSach = item.iMaSach;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (int)item.dDonGia;
                kn.ChiTietDonHangs.Add(ctDH);
            }
            kn.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}