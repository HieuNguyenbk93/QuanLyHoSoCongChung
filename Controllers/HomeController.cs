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
        private NhanVienRp _obj1 = new NhanVienRp();
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

        public ActionResult Get_CongChungById(int Id)
        {
            CongChungGet result = _obj.CongChung_Get(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

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

        public string TestNgay(DateTime Ngay)
        {
            string res = _obj1.TestNgay(Ngay);
            return res;
        }
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
    }
}