using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int IDNhanVien { get; set; }
        public string FullNameNV { get; set; }
        public string SoDienThoai { get; set; }

    }
}