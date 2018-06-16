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
    public class QuanLyChuDeController : Controller
    {
        // GET: QuanLyChuDe
        KetNoi kn = new KetNoi();
        public ActionResult Index(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 10;
            return View(kn.ChuDes.ToList().ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult ThemMoiChuDe()
        {          
            return View();
        }
        [HttpPost]

        public ActionResult ThemMoiChuDe(ChuDe chude)
        {
            if (ModelState.IsValid)
            {
                kn.ChuDes.Add(chude);
                kn.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult ChinhSuachude(int machude)
        {
            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = kn.ChuDes.SingleOrDefault(n => n.MaChuDe == machude);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chude);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuachude(ChuDe chude, FormCollection f)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                kn.Entry(chude).State = System.Data.Entity.EntityState.Modified;
                kn.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult HienThi(int MaChuDe)
        {

            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = kn.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chude);

        }
        [HttpGet]
        public ActionResult Xoa(int MaChuDe)
        {
            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = kn.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chude);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe chude = kn.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            kn.ChuDes.Remove(chude);
            kn.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}