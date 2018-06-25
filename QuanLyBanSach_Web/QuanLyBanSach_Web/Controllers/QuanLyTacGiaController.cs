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
    public class QuanLyTacGiaController : Controller
    {
        // GET: QuanLyTacGia
        KetNoi kn = new KetNoi();
        public ActionResult Index(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 10;
            return View(kn.TacGias.ToList().ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult ThemMoiTacGia()
        {
            return View();
        }
        [HttpPost]

        public ActionResult ThemMoiTacGia(TacGia TG)
        {
            if (ModelState.IsValid)
            {
                kn.TacGias.Add(TG);
                kn.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSua(int MaTG)
        {
            //Lấy ra đối tượng sách theo mã 
            TacGia TG = kn.TacGias.SingleOrDefault(n => n.MaTG == MaTG);
            if (TG == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(TG);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TacGia TG)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                kn.Entry(TG).State = System.Data.Entity.EntityState.Modified;
                kn.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult HienThi(int MaTG)
        {

            //Lấy ra đối tượng sách theo mã 
            TacGia TG = kn.TacGias.SingleOrDefault(n => n.MaTG == MaTG);
            if (TG == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(TG);

        }
        [HttpGet]
        public ActionResult Xoa(int MaTG)
        {
            //Lấy ra đối tượng sách theo mã 
            TacGia TG = kn.TacGias.SingleOrDefault(n => n.MaTG == MaTG);
            if (TG == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(TG);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaTG)
        {
            TacGia TG = kn.TacGias.SingleOrDefault(n => n.MaTG == MaTG);
            if (TG == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            kn.TacGias.Remove(TG);
            kn.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult TimKiem(FormCollection fc, int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 1;
            string giatri = fc["txtgiatri"];
            List<TacGia> TG = kn.TacGias.Where(a => a.TenTG.Contains(giatri)).ToList();
            return View(TG.OrderBy(a => a.TenTG).ToPagedList(pagenumber, pagesize));
        }
    }
}