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
    public class QuanLyNhaXuatBanController : Controller
    {
        // GET: QuanLyNhaXuatBan
        KetNoi kn = new KetNoi();
        public ActionResult Index(int? page)
        {
            int PageNumber = (page ?? 1);
            int PageSize = 10;
            return View(kn.NhaXuatBans.ToList().ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(NhaXuatBan NXB)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            else
            {
                kn.NhaXuatBans.Add(NXB);
                kn.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult ChinhSuaNXB(int MaNXB)
        {
            //Lấy ra đối tượng sách theo mã 
            NhaXuatBan NXB = kn.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSuaNXB(NhaXuatBan NXB)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                kn.Entry(NXB).State = System.Data.Entity.EntityState.Modified;
                kn.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        public ActionResult HienThi(int MaNXB)
        {

            //Lấy ra đối tượng sách theo mã 
            NhaXuatBan NXB = kn.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(NXB);

        }
        [HttpGet]
        public ActionResult Xoa(int MaNXB )
        {
            //Lấy ra đối tượng sách theo mã 
            NhaXuatBan NXB = kn.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(NXB);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan NXB = kn.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            kn.NhaXuatBans.Remove(NXB);
            kn.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult TimKiem(FormCollection fc, int? page)
        {
            int pagenumber = (page ?? 1);
            int pagesize = 1;
            string giatri = fc["txtgiatri"];
            List<NhaXuatBan> NXB = kn.NhaXuatBans.Where(a => a.TenNXB.Contains(giatri)).ToList();
            return View(NXB.OrderBy(a => a.TenNXB).ToPagedList(pagenumber, pagesize));
        }
    }
}