using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanSach_Web.Models.Data
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã Khách Hàng ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaKH { get; set; }

            [Display(Name = "Tên Khách Hàng ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TenKH { get; set; }

            [Display(Name = "Tài Khoản ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TaiKhoan { get; set; }

            [Display(Name = "Mật Khẩu ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string MatKhau { get; set; }

            [Display(Name = "Email")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string Email { get; set; }

            [Display(Name = "Giới Tính ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string GioiTinh { get; set; }

            [Display(Name = "Số Điện Thoại ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string SDT { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày cập nhật ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public DateTime? NgaySinh { get; set; }
        }
    }
}