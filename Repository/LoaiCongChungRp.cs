using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class LoaiCongChungRp
    {
        private DbConnectContext _context;

        public LoaiCongChungRp()
        {
            _context = new DbConnectContext();
        }

        public List<LoaiCongChung> LoaiCongChung_GetList(int pageSize, int pageIndex, string strTen)
        {
            var data = _context.Database.SqlQuery<LoaiCongChung>("LoaiCongChung_GetData @pageSize, @pageIndex, @strTen",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@strTen", strTen)
                ).ToList();
            return data;
        }
    }
}