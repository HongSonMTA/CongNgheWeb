using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;
namespace QuanLyBanSach_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Login()
        {
            if (Session["Username"] != null)
            {
                Session["Username"] = null;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            using (KetNoi db = new KetNoi())
            {
                var userDetail = db.TaiKhoans.Where(x =>x.TaiKhoan1 == username && x.MatKhau == password).FirstOrDefault();
                if (userDetail == null)
                {
                    ViewBag.ThongBao = "Đăng nhập Không Thành Công";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    Session["Username"] = userDetail.TaiKhoan1;
                    if (userDetail.PhanQuyen == 1)
                    {
                        return RedirectToAction("Index", "QuanLySach");
                    }
                    else
                    {
                        ViewBag.ThongBao = "Đăng nhập Không Thành Công";
                        return RedirectToAction("Login", "Login");
                    }
                }
            }
        }
        public ActionResult Loginkh()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Loginkh(string username, string password)
        {
            using (KetNoi db = new KetNoi())
            {
                var userDetail = db.TaiKhoans.Where(x => x.TaiKhoan1 == username && x.MatKhau == password).FirstOrDefault();
                if (userDetail == null)
                {
                    return RedirectToAction("Loginkh", "Login");
                }
                else
                {
                    Session["Username"] = userDetail.TaiKhoan1;
                    if (userDetail.PhanQuyen != 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Loginkh", "Login");
                    }
                }
            }
        }
    }
}