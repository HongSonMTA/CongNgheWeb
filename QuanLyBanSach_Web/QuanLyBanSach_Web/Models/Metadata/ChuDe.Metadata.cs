using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanSach_Web.Models.Data
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            [Display(Name = "Mã Chủ Đề ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaChuDe { get; set; }

            [Display(Name = "Tên Chủ Đề ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TenChuDe { get; set; }
        }
    }
}