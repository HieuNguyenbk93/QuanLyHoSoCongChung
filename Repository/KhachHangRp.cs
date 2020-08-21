using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class KhachHangRp
    {
        private DbConnectContext _context;

        public KhachHangRp()
        {
            _context = new DbConnectContext();
        }
        public List<KhachHang> KhachHang_GetList(int pageSize, int pageIndex, string strTen)
        {
            var data = _context.Database.SqlQuery<KhachHang>("KhachHang_GetData @pageSize, @pageIndex, @strTen",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@strTen", strTen)
                ).ToList();
            return data;
        }
    }
}