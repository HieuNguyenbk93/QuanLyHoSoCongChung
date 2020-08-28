using QuanLyHoSoCongChung.Models;
using QuanLyHoSoCongChung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.XlsIO;

namespace QuanLyHoSoCongChung.Controllers
{
    public class HomeController : Controller
    {
        GenericRepository<CongChung> _context = null;
        private CongChungRp _obj = new CongChungRp();
        public ActionResult Index()
        {
            //var nv = new AccountNhanVien();
            var session = Session["UserID"];
            if (session != null)
            {
                var role = Session["Role"];
                var name = Session["UserName"];
                
                ViewBag.User = name;
                ViewBag.IDUser = session;
                ViewBag.Role = role;
                //Response.Write(role);
                //nv.ID = int.Parse(session.ToString());
                //nv.FullName = name.ToString();
                //nv.Role = int.Parse(role.ToString());
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Phòng giải pháp - Trung tâm Công Nghệ Thông Tin - Viễn Thông Bắc Ninh.";

            return View();
        }

        public ActionResult BaoCao()
        {
            var session = Session["UserID"];
            if (session != null)
            {
                var role = Session["Role"];
                var name = Session["UserName"];
                //Response.Write(name);
                ViewBag.Message = "Báo cáo thông kê";
                ViewBag.User = name;
                ViewBag.Role = role;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        //Thêm mới công chứng
        public string Insert_CongChung(CongChung model)
        {
            var name = Session["User"];
            var ssid = Session["UserID"];
            var ssrole = Session["Role"];
            int role = int.Parse(ssrole.ToString());
            int id = int.Parse(ssid.ToString());
            _context = new GenericRepository<CongChung>();
            if (model != null)
            {
                CongChung cc = new CongChung();
                cc = model;
                if (role != 1)
                {
                    cc.IDNhanVien = id;
                }
                _context.Insert(cc);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }

        // Sửa công chứng
        public string Update_CongChung(CongChung model)
        {
            _context = new GenericRepository<CongChung>();
            if (model != null)
            {
                CongChung cc = new CongChung();
                cc = model;
                _context.Update(cc);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }

        // Lấy công chứng theo id
        public ActionResult Get_CongChungById(int Id)
        {
            CongChungGet result = _obj.CongChung_Get(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Tìm kiếm trong hồ sơ công chứng
        public ActionResult Get_CongChung(string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType, string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien)
        {
            var ssid = Session["UserID"];
            var ssrole = Session["Role"];
            int role = int.Parse(ssrole.ToString());
            int id = int.Parse(ssid.ToString());
            if (role != 1)
            {
                IDNhanVien = id;
            }
            if (NgayStart == null)
            {
                NgayStart = "";
            }
            if (NgayStop == null)
            {
                NgayStop = "";
            }

            List<CongChungGet> result = _obj.CongChung_GetList(NgayStart, NgayStop, strInforA, strInforB, IDType, strContent, PhiCongChung, PhiHoaHong, IDKhachHang, IDCongChungVien, IDNhanVien);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Lấy 5 công chứng gần nhất
        public ActionResult Get_CongChungNew(int count)
        {
            var session = Session["UserID"];
            var ssrole = Session["Role"];
            int id = int.Parse(session.ToString());
            int role = int.Parse(ssrole.ToString());
            List<CongChungGet> result = _obj.CongChung_GetNew(count,role,id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public string Delete_CongChung(CongChung model)
        {
            _context = new GenericRepository<CongChung>();
            if (model != null)
            {
                int x = model.IDCongChung;
                _context.Delete(x);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not delete";
            }
        }

        public void CreateDocument()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel97to2003;
                IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                worksheet.Range["A1"].Text = "Hello World";
                worksheet.Range["A1"].WrapText = true;
                worksheet.Range["A2"].Text = "Hello World2";
                workbook.SaveAs("Sample.xlsx", ExcelSaveType.SaveAsXLS, HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
            }
        }
    }
}