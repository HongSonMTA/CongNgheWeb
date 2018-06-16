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
    public class QuanLySachController : Controller
    {
        // GET: QuanLySach
        KetNoi kn = new KetNoi();
        public ActionResult Index(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 10;
            return View(kn.Saches.ToList().ToPagedList(PageNumber,PageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.MaChuDe = new SelectList(kn.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(kn.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB"); ;
            return View();
        }
        [HttpPost]

        public ActionResult ThemMoi(Sach sach, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaChuDe = new SelectList(kn.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(kn.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB"); ;
            if(fileUpload == null){
                ViewBag.ThongBao = "Chọn Hình Ảnh";
            }
            if (ModelState.IsValid)
            {
                //Lưu Đường Dẫn 
                var filename = Path.GetFileName(fileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/AnhBia" ),filename);
                // Kiểm Tra Hình Ảnh
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                kn.Saches.Add(sach);
                kn.SaveChanges();
            }
            return View();
        }
    }
}