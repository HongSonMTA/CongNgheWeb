using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;
using PagedList;

namespace QuanLyBanSach_Web.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        KetNoi db = new KetNoi();
        // GET: TaiKhoan
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string user = Session["Username"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(a => a.TaiKhoan == user);
            return View(kh);
        }
        public ActionResult DangKy()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DangKy(string firstName, string ngaysinh, string gioitinh, string tel, string email, string diachi, string username, string password)
        {
            if (db.TaiKhoans.Where(a => a.TaiKhoan1 == username).Count() > 0)
            {
                return RedirectToAction("DangKy", "TaiKhoan");
            }
            else
            {
                TaiKhoan tk = new TaiKhoan();
                tk.TaiKhoan1 = username;
                tk.MatKhau = password;
                tk.PhanQuyen = 2;
                db.TaiKhoans.Add(tk);
                db.SaveChanges();
                KhachHang kh = new KhachHang();
                kh.TenKH = firstName;
                kh.NgaySinh = Convert.ToDateTime(ngaysinh);
                kh.GioiTinh = gioitinh;
                kh.SDT = tel;
                kh.Email = email;
                kh.DiaChi = diachi;
                kh.TaiKhoan = username;
                db.KhachHangs.Add(kh);
                db.SaveChanges();

            }
            return RedirectToAction("Loginkh", "Login");
        }
    }
}