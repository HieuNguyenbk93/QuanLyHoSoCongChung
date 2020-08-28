using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Models
{
    public class DbConnectContext : DbContext
    {
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<AccountNhanVien> AccountNhanViens { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<CongChungVien> CongChungViens { get; set; }
        public virtual DbSet<LoaiCongChung> LoaiCongChungs { get; set; }
        public virtual DbSet<CongChung> CongChungs { get; set; }
    }
}