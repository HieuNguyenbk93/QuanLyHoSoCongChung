using QuanLyHoSoCongChung.Models;
using QuanLyHoSoCongChung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyHoSoCongChung.Controllers
{
    public class HomeController : Controller
    {
        GenericRepository<CongChung> _context = null;
        private CongChungRp _obj = new CongChungRp();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BaoCao()
        {
            ViewBag.Message = "Báo cáo thông kê";
            return View();
        }

        //Thêm mới công chứng
        public string Insert_CongChung(CongChung model)
        {
            _context = new GenericRepository<CongChung>();
            if (model != null)
            {
                CongChung cc = new CongChung();
                cc = model;
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
            List<CongChungGet> result = _obj.CongChung_GetNew(count);
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
    }
}