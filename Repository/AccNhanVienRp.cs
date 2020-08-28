using QuanLyHoSoCongChung.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyHoSoCongChung.Repository
{
    public class AccNhanVienRp
    {
        private DbConnectContext _context;

        public AccNhanVienRp()
        {
            _context = new DbConnectContext();
        }

        public AccountNhanVien Login(string email, string password)
        {
            var data = _context.Database.SqlQuery<AccountNhanVien>("Login @email, @password",
                new SqlParameter("@email", email),
                new SqlParameter("@password", password)
                ).SingleOrDefault();
            return data;
        }

        public List<AccountNhanVienGet> AccNhanVien_GetList(int pageSize, int pageIndex, string strTen)
        {
            var data = _context.Database.SqlQuery<AccountNhanVienGet>("AccNhanVien_GetData @pageSize, @pageIndex, @strTen",
                new SqlParameter("@pageSize", pageSize),
                new SqlParameter("@pageIndex", pageIndex),
                new SqlParameter("@strTen", strTen)
                ).ToList();
            return data;
        }

        public List<Role> Role_GetList()
        {
            var data = _context.Database.SqlQuery<Role>("Role_GetData").ToList();
            return data;
        }
    }
}