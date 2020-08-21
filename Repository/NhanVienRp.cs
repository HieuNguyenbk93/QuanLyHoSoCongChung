using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class NhanVienRp
    {
        private DbConnectContext _context;

        public NhanVienRp()
        {
            _context = new DbConnectContext();
        }

        public string TestNgay (DateTime ngay)
        {
            var result = _context.Database.SqlQuery<string>("TestNgay @Ngay",
                new SqlParameter("@Ngay", ngay)
                ).SingleOrDefault();
            return result;
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

        public List<NhanVien> NhanVien_GetList(int pageSize, int pageIndex, string strTen)
        {
            var data = _context.Database.SqlQuery<NhanVien>("NhanVien_GetData @pageSize, @pageIndex, @strTen",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@strTen", strTen)
                ).ToList();
            return data;
        }
    }
}