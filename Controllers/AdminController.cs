using QuanLyHoSoCongChung.Models;
using QuanLyHoSoCongChung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyHoSoCongChung.Controllers
{
    public class AdminController : Controller
    {
        GenericRepository<AccountNhanVien> _context = null;
        private AccNhanVienRp _obj = new AccNhanVienRp();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Admin");
        }

        public string CheckLogin(string email, string password, bool remember)
        {
            AccountNhanVien result = _obj.Login(email, password);
            if (result != null)
            {
                Session["UserID"] = result.ID;
                Session["UserName"] = result.FullName;
                Session["Role"] = result.Role;
                ViewBag.User = result.FullName;
                //Response.Write(Session["UserID"]);
                return "Đăng nhập thành công";

            }
            return "Đăng nhập thất bại";
        }
    }
}