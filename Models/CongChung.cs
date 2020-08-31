using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CongChung")]
    public class CongChung
    {
        [Key]
        public int IDCongChung { get; set; }
        public string ContentCongChung { get; set; }
        public int IDType { get; set; }
        public string InforA { get; set; }
        public string InforB { get; set; }
        public int PhiCongChung { get; set; }
        public int PhiHoaHong { get; set; }
        public int IDKhachHang { get; set; }
        public int IDCongChungVien { get; set; }
        public int IDNhanVien { get; set; }
        public DateTime NgayTao { get; set; }
    }

    public class CongChungGet
    {
        [Key]
        public int IDCongChung { get; set; }
        public string ContentCongChung { get; set; }
        public int IDType { get; set; }
        public string TypeCC { get; set; }
        public string InforA { get; set; }
        public string InforB { get; set; }
        public int PhiCongChung { get; set; }
        public int PhiHoaHong { get; set; }
        public int? IDKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public int IDCongChungVien { get; set; }
        public string FullNameCCV { get; set; }
        public int IDNhanVien { get; set; }
        public string FullName { get; set; }
        public DateTime NgayTao { get; set; }
        public int TotalRow { get; set; }
    }
}