namespace QuanLyBanSach_Web.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name = " Mã Khách Hàng")]
        [Required(ErrorMessage ="{0} Không được để trống")]
        public int MaKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string TenKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài Khoản")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name = " Mật Khẩu")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Display(Name = " Email")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string Email { get; set; }

        [StringLength(5)]
        [Display(Name = " Giới Tính")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string GioiTinh { get; set; }

        [StringLength(15)]
        [Display(Name = " Số Điện Thoại")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public string SDT { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = " Ngày Sinh")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public DateTime? NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [Display(Name = " Đơn Hàng")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
