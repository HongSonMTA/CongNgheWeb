using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;

namespace QuanLyBanSach_Web.Controllers
{
    public class TacGiaController : Controller
    {
        // GET: TacGia
        KetNoi kn = new KetNoi();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TacGia()
        {
            return PartialView(kn.TacGias.Take(7).ToList());
        }
        public ActionResult DanhSachTacGia()
        {
            return View(kn.TacGias.ToList());
        }
    }
}