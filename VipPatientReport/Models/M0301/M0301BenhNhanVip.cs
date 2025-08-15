using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipPatientReport.Models.M0301
{
    [Table("Tien_Mau1")]
    public class M0301BenhNhanVip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Mã y tế")]
        public string MaYTe { get; set; } = string.Empty;

        [Required, StringLength(50)]
        [Display(Name = "Mã tiếp nhận")]
        public string MaTiepNhan { get; set; } = string.Empty;

        [Required, StringLength(200)]
        [Display(Name = "Họ và tên")]
        public string HoTen { get; set; } = string.Empty;

        [Display(Name = "Năm sinh")]
        [Range(1900, 2100)]
        public int NamSinh { get; set; }

        [Display(Name = "Giới tính")]
        [StringLength(10)]
        public string GioiTinh { get; set; } = "Nam";

        [Display(Name = "CCCD")]
        [StringLength(20)]
        public string CCCD { get; set; } = string.Empty;

        [Display(Name = "PASSPORT")]
        [StringLength(20)]
        public string PASSPORT { get; set; } = string.Empty;

        [Display(Name = "Quốc tịch")]
        [StringLength(100)]
        public string QuocTich { get; set; } = "Việt Nam";

        [Display(Name = "Tên chuyên gia")]
        [StringLength(150)]
        public string TenChuyenGia { get; set; } = string.Empty;

        [Display(Name = "Gói khám")]
        [StringLength(150)]
        public string GoiKham { get; set; } = string.Empty;

        [Display(Name = "Phòng khám")]
        [StringLength(100)]
        public string PhongKham { get; set; } = string.Empty;

        [Display(Name = "Thời gian tiếp nhận")]
        public DateTime ThoiGianTiepNhan { get; set; }

        [Display(Name = "Người tiếp nhận")]
        [StringLength(150)]
        public string NguoiTiepNhan { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; } = false;

        [Display(Name = "Chi nhánh")]
        public long IdChiNhanh { get; set; }
    }
}
