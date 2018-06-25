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
        public ViewResult SachTheoNXB(int? page, int MaNXB = 0)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            NhaXuatBan NXB = kn.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> List = kn.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (List.Count == 0)
            {
                ViewBag.Sach = "Không Có Cuốn Sách Nào";
            }
            return View(List.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DanhMucNXB()
        {
            return View(kn.NhaXuatBans.ToList());
        }
    }
}