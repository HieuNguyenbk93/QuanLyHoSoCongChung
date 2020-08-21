using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CongChungVien")]
    public class CongChungVien
    {
        [Key]
        public int IDCongChungVien { get; set; }
        public string FullNameCCV { get; set; }
        public string SoDienThoai { get; set; }
    }
}