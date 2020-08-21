using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int IDKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string CoQuan { get; set; }
        public string SoDienThoai { get; set; }
    }
}