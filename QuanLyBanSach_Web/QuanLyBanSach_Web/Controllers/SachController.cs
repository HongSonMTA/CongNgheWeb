using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;
namespace QuanLyBanSach_Web.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        KetNoi kn = new KetNoi();
        public PartialViewResult SachMoiPartial( )
        {
            var ListSachMoi = kn.Saches.Where(n => n.TrangThai == 1).Take(7).ToList();
            return PartialView(ListSachMoi);
        }
        public PartialViewResult SachPartial(int TrangThai)
        {
            var ListSachMoi = kn.Saches.Where(n=>n.TrangThai == TrangThai).Take(5).ToList();
            return PartialView(ListSachMoi);
        }

        //Xem Chi Tiết
        public ViewResult ChiTietSach(int Masach = 0)
        {
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == Masach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.TenChuDe = kn.ChuDes.Single(n => n.MaChuDe == sach.MaChuDe).TenChuDe;
            ViewBag.NhaXuatBan = kn.NhaXuatBans.Single(n => n.MaNXB == sach.MaNXB).TenNXB;
            return View(sach);
        }
        public PartialViewResult SachSapXBPartial(int TT)
        {
            var List = kn.Saches.Where(n => n.TrangThai == TT).Take(5).ToList();
            return PartialView(List);
        }
        public PartialViewResult SachOnThiPartial(int machude = 10)
        {
            var List = kn.Saches.Where(n => n.MaChuDe == machude).Take(7).ToList();
            return PartialView(List);
        }
    }
}