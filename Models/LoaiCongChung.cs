using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LoaiCongChung")]
    public class LoaiCongChung
    {
        [Key]
        public int IDType { get; set; }
        public string TypeCC { get; set; }
        public string NameType { get; set; }
    }
}