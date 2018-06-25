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
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLyDonHang
         KetNoi db = new KetNoi();
        // GET: QuanLyLoaiSanPham
        public ActionResult Index(int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 10;
            return View(db.DonHangs.ToList().OrderBy(n => n.TinhTrangDH).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            //trả về đói tượng lapotp với điều kiện

            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.TenKH), "MaKH", "TenKH");
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDH == MaDonHang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang dh)
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.TenKH), "MaKH", "TenKH");
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(dh).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int MaDonHang)
        {

            //trả về đói tượng lapotp với điều kiện
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDH == MaDonHang);
            if (dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(dh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDonHang)
        {
            DonHang dh = db.DonHangs.SingleOrDefault(n => n.MaDH == MaDonHang);
            List<ChiTietDonHang> ctdh = db.ChiTietDonHangs.Where(n => n.MaDH == dh.MaDH).ToList();
            foreach (var item in ctdh)
            {
                db.ChiTietDonHangs.Remove(item);
                db.SaveChanges();
            }
            db.DonHangs.Remove(dh);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}