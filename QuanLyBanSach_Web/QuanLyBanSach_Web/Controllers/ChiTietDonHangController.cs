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
    public class ChiTietDonHangController : Controller
    {
        // GET: ChiTietDonHang
        KetNoi db = new KetNoi();
        // GET: ChiTietDonHang
        public ActionResult Index(int MaDonHang, int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 5;
            return View(db.ChiTietDonHangs.ToList().Where(x => x.MaDH == MaDonHang).OrderBy(n => n.MaDH).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult HienThiChiTietDonHang(int MaDonHang)
        {

            //trả về đói tượng lapotp với điều kiện
            ChiTietDonHang ctdh = db.ChiTietDonHangs.FirstOrDefault(n => n.MaDH == MaDonHang);
            if (ctdh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctdh);
        }
        [HttpGet]
        public ActionResult Xoa(int MaDonHang, int MaSach)
        {

            //trả về đói tượng lapotp với điều kiện
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Where(n => n.MaDH == MaDonHang && n.MaSach == MaSach).FirstOrDefault();
            if (ctdh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ctdh);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDonHang, int MaSach)
        {
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Where(n => n.MaDH == MaDonHang && n.MaSach == MaSach).FirstOrDefault();
            DonHang dh = db.DonHangs.FirstOrDefault(n => n.MaDH == MaDonHang);
            if (ctdh == null && dh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChiTietDonHangs.Remove(ctdh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}