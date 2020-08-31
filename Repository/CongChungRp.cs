using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class CongChungRp
    {
        private DbConnectContext _context;

        public CongChungRp()
        {
            _context = new DbConnectContext();
        }

        public CongChungGet CongChung_Get (int Id)
        {
            var data = _context.Database.SqlQuery<CongChungGet>("CongChung_Get @Id",
                new SqlParameter("@Id", Id)).FirstOrDefault();
            return data;
        }

        public List<CongChungGet> CongChung_GetNew (int count, int role, int id)
        {
            var data = _context.Database.SqlQuery<CongChungGet>("CongChung_GetNew @count, @id, @role",
                new SqlParameter("@count", count),
                new SqlParameter("@id", id),
                new SqlParameter("@role", role)
                ).ToList();
            return data;
        }

        public List<CongChungGet> CongChung_GetList(string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType, string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien)
        {
            var data = _context.Database.SqlQuery<CongChungGet>("CongChung_GetData @NgayStart, @NgayStop, @strInforA, @strInforB, @IDType, @strContent, @PhiCongChung, @PhiHoaHong, @IDKhachHang, @IDCongChungVien, @IDNhanVien",
                new SqlParameter("@NgayStart", NgayStart),
                new SqlParameter("@NgayStop", NgayStop),
                new SqlParameter("@strInforA", strInforA),
                new SqlParameter("@strInforB", strInforB),
                new SqlParameter("@IDType", IDType),
                new SqlParameter("@strContent", strContent),
                new SqlParameter("@PhiCongChung", PhiCongChung),
                new SqlParameter("@PhiHoaHong", PhiHoaHong),
                new SqlParameter("@IDKhachHang", IDKhachHang),
                new SqlParameter("@IDCongChungVien", IDCongChungVien),
                new SqlParameter("@IDNhanVien", IDNhanVien)
                ).ToList();
            return data;
        }

        public List<CongChungGet> CongChung_GetListAll(int pageIndex, int pageSize, string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType, string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien)
        {
            var data = _context.Database.SqlQuery<CongChungGet>("CongChung_GetAll @pageSize, @pageIndex, @NgayStart, @NgayStop, @strInforA, @strInforB, @IDType, @strContent, @PhiCongChung, @PhiHoaHong, @IDKhachHang, @IDCongChungVien, @IDNhanVien",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@NgayStart", NgayStart),
                new SqlParameter("@NgayStop", NgayStop),
                new SqlParameter("@strInforA", strInforA),
                new SqlParameter("@strInforB", strInforB),
                new SqlParameter("@IDType", IDType),
                new SqlParameter("@strContent", strContent),
                new SqlParameter("@PhiCongChung", PhiCongChung),
                new SqlParameter("@PhiHoaHong", PhiHoaHong),
                new SqlParameter("@IDKhachHang", IDKhachHang),
                new SqlParameter("@IDCongChungVien", IDCongChungVien),
                new SqlParameter("@IDNhanVien", IDNhanVien)
                ).ToList();
            return data;
        }
    }

    
}