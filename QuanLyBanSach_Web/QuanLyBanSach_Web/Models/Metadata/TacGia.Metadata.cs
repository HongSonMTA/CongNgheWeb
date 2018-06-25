using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanSach_Web.Models.Data
{
    [MetadataTypeAttribute(typeof(TacGiaMetadata))]
    public partial class TacGia
    {
        internal sealed class TacGiaMetadata
        {
            [Display(Name = "Mã Tác Giả ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaTG { get; set; }

            [Display(Name = "Tên Tác Giả ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(50)]
            public string TenTG { get; set; }

            [Display(Name = "Địa Chỉ ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(200)]
            public string DiaChi { get; set; }

            [Display(Name = "Tiểu Sử ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TieuSu { get; set; }

            [Display(Name = "SĐT")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(15)]
            public string SDT { get; set; }
        }
    }
}