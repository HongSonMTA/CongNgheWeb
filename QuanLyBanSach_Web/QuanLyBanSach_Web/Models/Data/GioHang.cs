using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyBanSach_Web.Models;

namespace QuanLyBanSach_Web.Models.Data
{
    public class GioHang
    {
        KetNoi kn = new KetNoi();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = kn.Saches.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}