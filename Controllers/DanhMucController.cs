using QuanLyHoSoCongChung.Models;
using QuanLyHoSoCongChung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyHoSoCongChung.Controllers
{
    public class DanhMucController : Controller
    {
        GenericRepository<NhanVien> _context = null;
        GenericRepository<CongChungVien> _contextCCV = null;
        GenericRepository<KhachHang> _contextKH = null;
        GenericRepository<LoaiCongChung> _contextLCC = null;
        private NhanVienRp _obj = new NhanVienRp();
        private CongChungVienRp _objCCV = new CongChungVienRp();
        private KhachHangRp _objKH = new KhachHangRp();
        private LoaiCongChungRp _objLCC = new LoaiCongChungRp();

        // GET: DanhMuc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NhanVien()
        {
            return View();
        }

        public int Count_NhanVien(int DieuKien)
        {
            int res = _obj.GetCount(DieuKien);
            return res;
        }

        [HttpGet]
        public ActionResult Get_NhanVien(int pageSize, int pageIndex, string strTen)
        {
            List<NhanVien> result = _obj.NhanVien_GetList(pageSize, pageIndex, strTen);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string Insert_NhanVien(NhanVien model)
        {
            _context = new GenericRepository<NhanVien>();
            if (model != null)
            {
                NhanVien nv = new NhanVien();
                nv.FullNameNV = model.FullNameNV;
                nv.SoDienThoai = model.SoDienThoai;
                _context.Insert(nv);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not Inserted";
            }
        }

        public string Update_NhanVien(NhanVien model)
        {
            _context = new GenericRepository<NhanVien>();
            if (model != null)
            {
                NhanVien nv = new NhanVien();
                nv.IDNhanVien = model.IDNhanVien;
                nv.FullNameNV = model.FullNameNV;
                nv.SoDienThoai = model.SoDienThoai;
                _context.Update(nv);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }

        public string Delete_NhanVien(NhanVien model)
        {
            _context = new GenericRepository<NhanVien>();
            if (model != null)
            {
                int x = model.IDNhanVien;
                _context.Delete(x);
                _context.Save();
                return "Successfully";
            }
            else
            {
                return "Not delete";
            }
        }

        public ActionResult KhachHang()
        {
            return View();
        }

        public ActionResult Get_KhachHang(int pageSize, int pageIndex, string strTen)
        {
            List<KhachHang> result = _objKH.KhachHang_GetList(pageSize, pageIndex, strTen);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string Insert_KhachHang(KhachHang model)
        {
            _contextKH = new GenericRepository<KhachHang>();
            if (model != null)
            {
                KhachHang kh = new KhachHang();
                kh.TenKhachHang = model.TenKhachHang;
                kh.CoQuan = model.CoQuan;
                kh.SoDienThoai = model.SoDienThoai;
                _contextKH.Insert(kh);
                _contextKH.Save();
                return "Successfully";
            }
            else
            {
                return "Not Inserted";
            }
        }

        public string Update_KhachHang(KhachHang model)
        {
            _contextKH = new GenericRepository<KhachHang>();
            if (model != null)
            {
                KhachHang kh = new KhachHang();
                kh.IDKhachHang = model.IDKhachHang;
                kh.TenKhachHang = model.TenKhachHang;
                kh.CoQuan = model.CoQuan;
                kh.SoDienThoai = model.SoDienThoai;
                _contextKH.Update(kh);
                _contextKH.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }
        public string Delete_KhachHang(KhachHang model)
        {
            _contextKH = new GenericRepository<KhachHang>();
            if (model != null)
            {
                int x = model.IDKhachHang;
                _contextKH.Delete(x);
                _contextKH.Save();
                return "Successfully";
            }
            else
            {
                return "Not delete";
            }
        }

        public ActionResult CongChungVien()
        {
            return View();
        }

        public ActionResult Get_CongChungVien(int pageSize, int pageIndex, string strTen)
        {
            List<CongChungVien> result = _objCCV.CongChungVien_GetList(pageSize, pageIndex, strTen);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string Insert_CongChungVien(CongChungVien model)
        {
            _contextCCV = new GenericRepository<CongChungVien>();
            if (model != null)
            {
                CongChungVien ccv = new CongChungVien();
                ccv.FullNameCCV = model.FullNameCCV;
                ccv.SoDienThoai = model.SoDienThoai;
                _contextCCV.Insert(ccv);
                _contextCCV.Save();
                return "Successfully";
            }
            else
            {
                return "Not Inserted";
            }
        }

        public string Update_CongChungVien(CongChungVien model)
        {
            _contextCCV = new GenericRepository<CongChungVien>();
            if (model != null)
            {
                CongChungVien ccv = new CongChungVien();
                ccv.IDCongChungVien = model.IDCongChungVien;
                ccv.FullNameCCV = model.FullNameCCV;
                ccv.SoDienThoai = model.SoDienThoai;
                _contextCCV.Update(ccv);
                _contextCCV.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }
        public string Delete_CongChungVien(CongChungVien model)
        {
            _contextCCV = new GenericRepository<CongChungVien>();
            if (model != null)
            {
                int x = model.IDCongChungVien;
                _contextCCV.Delete(x);
                _contextCCV.Save();
                return "Successfully";
            }
            else
            {
                return "Not delete";
            }
        }

        public ActionResult LoaiCongChung()
        {
            return View();
        }

        public ActionResult Get_LoaiCongChung(int pageSize, int pageIndex, string strTen)
        {
            List<LoaiCongChung> result = _objLCC.LoaiCongChung_GetList(pageSize, pageIndex, strTen);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string Insert_LoaiCongChung(LoaiCongChung model)
        {
            _contextLCC = new GenericRepository<LoaiCongChung>();
            if (model != null)
            {
                LoaiCongChung lcc = new LoaiCongChung();
                lcc.TypeCC = model.TypeCC;
                lcc.NameType = model.NameType;
                _contextLCC.Insert(lcc);
                _contextLCC.Save();
                return "Successfully";
            }
            else
            {
                return "Not Inserted";
            }
        }

        public string Update_LoaiCongChung(LoaiCongChung model)
        {
            _contextLCC = new GenericRepository<LoaiCongChung>();
            if (model != null)
            {
                LoaiCongChung lcc = new LoaiCongChung();
                lcc.IDType = model.IDType;
                lcc.TypeCC = model.TypeCC;
                lcc.NameType = model.NameType;
                _contextLCC.Update(lcc);
                _contextLCC.Save();
                return "Successfully";
            }
            else
            {
                return "Not edit";
            }
        }

        public string Delete_LoaiCongChung(LoaiCongChung model)
        {
            _contextLCC = new GenericRepository<LoaiCongChung>();
            if (model != null)
            {
                int x = model.IDType;
                _contextLCC.Delete(x);
                _contextLCC.Save();
                return "Successfully";
            }
            else
            {
                return "Not delete";
            }
        }
    }
}