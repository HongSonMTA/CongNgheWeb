using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanSach_Web.Models.Data;
namespace QuanLyBanSach_Web.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: NhaXuatBan
        KetNoi kn = new KetNoi();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NhaXuatBan()
        {
            return PartialView(kn.NhaXuatBans.Take(7).ToList());
        }
        public ActionResult DanhMucNXB()
        {
            return View(kn.NhaXuatBans.ToList());
        }
    }
}