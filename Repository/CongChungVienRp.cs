using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class CongChungVienRp
    {
        private DbConnectContext _context;

        public CongChungVienRp()
        {
            _context = new DbConnectContext();
        }

        public int GetCount(int DieuKien)
        {
            if (DieuKien != 0)
            {
                var result = _context.Database.SqlQuery<int>("CountSL @DieuKien",
                new SqlParameter("@DieuKien", DieuKien)
                ).SingleOrDefault();
                return result;
            }
            else
            {
                return 0;
            }
        }

        public List<CongChungVien> CongChungVien_GetList(int pageSize, int pageIndex, string strTen)
        {
            var data = _context.Database.SqlQuery<CongChungVien>("CongChungVien_GetData @pageSize, @pageIndex, @strTen",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@strTen", strTen)
                ).ToList();
            return data;
        }
    }
}