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
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        KetNoi kn = new KetNoi();
        public ActionResult ChuDe()
        {
            return PartialView(kn.ChuDes.Take(6).ToList());
        }
        public ViewResult SachTheoChuDe(int? page, int MaChude = 0)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            ChuDe Cd = kn.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChude);
            if (Cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> List = kn.Saches.Where(n => n.MaChuDe == MaChude).OrderBy(n => n.GiaBan).ToList();
            if (List.Count == 0)
            {
                ViewBag.Sach = "Không Có Cuốn Sách Nào";
            }
            return View(List.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DanhMucChuDe()
        {
            return View(kn.ChuDes.ToList());
        }
    }
}