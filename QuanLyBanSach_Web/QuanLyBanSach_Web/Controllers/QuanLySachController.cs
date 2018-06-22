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
        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            ViewBag.MaChuDe = new SelectList(kn.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(kn.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB"); ;
            //Lấy ra đối tượng sách theo mã 
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(Sach sach, HttpPostedFileBase fileUpload)
        {
            ViewBag.MaChuDe = new SelectList(kn.ChuDes.ToList().OrderBy(n => n.TenChuDe), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(kn.NhaXuatBans.ToList().OrderBy(n => n.TenNXB), "MaNXB", "TenNXB"); ;
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn Hình Ảnh";
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Lưu Đường Dẫn 
                var filename = Path.GetFileName(fileUpload.FileName);
                var path = Path.Combine(Server.MapPath("~/AnhBia"), filename);
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
                //Thực hiện cập nhận trong model
                kn.Entry(sach).State = System.Data.Entity.EntityState.Modified;
                kn.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult HienThi(int MaSach)
        {

            //Lấy ra đối tượng sách theo mã 
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sach);

        }
        [HttpGet]
        public ActionResult Xoa(int MaSach)
        {
            //Lấy ra đối tượng sách theo mã 
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(sach);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaSach)
        {
            Sach sach = kn.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            kn.Saches.Remove(sach);
            kn.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}