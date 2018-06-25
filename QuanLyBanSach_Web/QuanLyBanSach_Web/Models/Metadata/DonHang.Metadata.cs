using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanSach_Web.Models.Data
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn H ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaDH { get; set; }

            [Display(Name = "Tình Trạng Thanh Toán ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public int? DaThanhToan { get; set; }

            [Display(Name = "Tình Trạng Đơn Hàng ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int? TinhTrangDH { get; set; }

            [Display(Name = "Ngày Đặt ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public DateTime? NgayDat { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày Giao ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public DateTime? NgayGiao { get; set; }

            [Display(Name = "Tên Khách Hàng ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int? MaKH { get; set; }

        }
    }
}