using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;
using PagedList;
using System.IO;

namespace QuanLyBanSach_Web.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        // GET: QuanLyKhachHang
        KetNoi db = new KetNoi();
        // GET: QuanLyLoaiSanPham
        public ActionResult Index(int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 5;
            return View(db.KhachHangs.ToList().OrderBy(n => n.MaKH).ToPagedList(pagenumber, pagesize));
        }
        public ActionResult HienThi(int MaKH)
        {

            //trả về đói tượng lapotp với điều kiện
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }


        [HttpGet]
        public ActionResult Xoa(int MaKH)
        {

            //trả về đói tượng lapotp với điều kiện
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaKH)
        {
            List<DonHang> dh = db.DonHangs.Where(x => x.MaKH == MaKH).ToList();
            foreach (var item in dh)
            {
                List<ChiTietDonHang> ctdh = db.ChiTietDonHangs.Where(x => x.MaDH == item.MaDH).ToList();
                foreach (var item1 in ctdh)
                {
                    db.ChiTietDonHangs.Remove(item1);
                    db.SaveChanges();
                }
                db.DonHangs.Remove(item);
                db.SaveChanges();
            }
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            string username = kh.TaiKhoan;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(x => x.TaiKhoan1 == username);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult TimKiem(FormCollection fc, int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 1;
            string giatri = fc["txtgiatri"];
            List<KhachHang> kh = db.KhachHangs.Where(a => a.TenKH.Contains(giatri)).ToList();
            return View(kh.OrderBy(a => a.TenKH).ToPagedList(pagenumber, pagesize));
        }
    }
}