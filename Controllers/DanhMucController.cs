﻿using QuanLyHoSoCongChung.Models;
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
        GenericRepository<AccountNhanVien> _contextAcc = null;
        private NhanVienRp _obj = new NhanVienRp();
        private CongChungVienRp _objCCV = new CongChungVienRp();
        private KhachHangRp _objKH = new KhachHangRp();
        private LoaiCongChungRp _objLCC = new LoaiCongChungRp();
        private AccNhanVienRp _objANV = new AccNhanVienRp();

        // GET: DanhMuc
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get_Role()
        {
            List<Role> result = _objANV.Role_GetList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AccountNhanVien()
        {
            var session = Session["UserID"];
            var role = Session["Role"];
            var name = Session["UserName"];
            ViewBag.User = name;
            ViewBag.Role = role;
            return View();
            //if (session != null)
            //{
            //    var role = Session["Role"].ToString();
            //    if (role == "1")
            //    {
            //        ViewBag.User = name;
            //        return View();
            //    }
            //    else
            //    {
            //        return RedirectToAction("Login", "Admin");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Admin");
            //}
        }
        public ActionResult Get_AccNhanVien(int pageSize, int pageIndex, string strTen)
        {
            List<AccountNhanVienGet> result = _objANV.AccNhanVien_GetList(pageSize, pageIndex, strTen);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public string Insert_AccNhanVien(AccountNhanVien model)
        {
            _contextAcc = new GenericRepository<AccountNhanVien>();
            if (model != null)
            {
                AccountNhanVien nv = new AccountNhanVien();
                nv.Email = model.Email;
                nv.Password = model.Password;
                nv.FullName = model.FullName;
                nv.Phone = model.Phone;
                nv.Role = model.Role;
                _contextAcc.Insert(nv);
                _contextAcc.Save();
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
            }
        }
        public string Update_AccNhanVien(AccountNhanVien model)
        {
            _contextAcc = new GenericRepository<AccountNhanVien>();
            if (model != null)
            {
                AccountNhanVien nv = new AccountNhanVien();
                nv.ID = model.ID;
                nv.Email = model.Email;
                nv.Password = model.Password;
                nv.FullName = model.FullName;
                nv.Phone = model.Phone;
                nv.Role = model.Role;
                _contextAcc.Update(nv);
                _contextAcc.Save();
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }
        public string Delete_AccNhanVien(AccountNhanVien model)
        {
            _contextAcc = new GenericRepository<AccountNhanVien>();
            if (model != null)
            {
                int x = model.ID;
                _contextAcc.Delete(x);
                _contextAcc.Save();
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
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
            //var session = Session["UserID"];
            //var name = Session["UserName"];
            //ViewBag.User = name;
            var session = Session["UserID"];
            var role = Session["Role"];
            var name = Session["UserName"];
            ViewBag.User = name;
            ViewBag.Role = role;
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
                //if (model.)
                KhachHang kh = new KhachHang();
                kh.TenKhachHang = model.TenKhachHang;
                kh.CoQuan = model.CoQuan;
                kh.SoDienThoai = model.SoDienThoai;
                _contextKH.Insert(kh);
                _contextKH.Save();
                return "Thêm mới thành công";
            }
            else
            {
                return "Thêm mới thất bại";
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
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
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
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        public ActionResult CongChungVien()
        {
            //var session = Session["UserID"];
            //var name = Session["UserName"];
            //ViewBag.User = name;
            var session = Session["UserID"];
            var role = Session["Role"];
            var name = Session["UserName"];
            ViewBag.User = name;
            ViewBag.Role = role;
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
                return "Thêm mới thành công";
            }
            else
            {
                return "Thêm mới thất bại";
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
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
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
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        public ActionResult LoaiCongChung()
        {
            //var session = Session["UserID"];
            //var name = Session["UserName"];
            //ViewBag.User = name;
            var session = Session["UserID"];
            var role = Session["Role"];
            var name = Session["UserName"];
            ViewBag.User = name;
            ViewBag.Role = role;
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
                return "Thêm thành công";
            }
            else
            {
                return "Thêm thất bại";
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
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
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
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}