using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanSach_Web.Models.Data
{
    [MetadataTypeAttribute(typeof(NXBMetadata))]
    public partial class NhaXuatBan
    {
        internal sealed class NXBMetadata
        {
            [Display(Name = "Mã NXB ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaNXB { get; set; }

            [Display(Name = "Tên NXB ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(50)]
            public string TenNXB { get; set; }

            [Display(Name = "Địa Chỉ ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(200)]
            public string DiaChi { get; set; }

            [Display(Name = "SĐT  ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            [StringLength(15)]
            public string SDT { get; set; }
        }
    }
}