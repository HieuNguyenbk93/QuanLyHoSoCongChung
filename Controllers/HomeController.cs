using QuanLyHoSoCongChung.Models;
using QuanLyHoSoCongChung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aspose.Cells;
using Syncfusion.Compression;
using System.Net;
using System.Data;
using System.IO;

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
                return "Thêm mới thành công";
            }
            else
            {
                return "Thêm mới thất bại";
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
                return "Sửa thành công";
            }
            else
            {
                return "Sửa thất bại";
            }
        }

        // Lấy công chứng theo id
        public ActionResult Get_CongChungById(int Id)
        {
            CongChungGet result = _obj.CongChung_Get(Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get_CongChungAll(int pageIndex, int pageSize, string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType, string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien)
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
            if (strInforA == null)
            {
                strInforA = "";
            }
            if (strInforB == null)
            {
                strInforB = "";
            }
            pageIndex = (pageIndex - 1) * pageSize;
            List<CongChungGet> result = _obj.CongChung_GetListAll(pageIndex, pageSize, NgayStart, NgayStop, strInforA, strInforB, IDType, strContent, PhiCongChung, PhiHoaHong, IDKhachHang, IDCongChungVien, IDNhanVien);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Tìm kiếm trong hồ sơ công chứng
        public ActionResult Get_CongChung(string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType,
            string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien)
        {
            //var ssid = Session["UserID"];
            //var ssrole = Session["Role"];
            //int role = int.Parse(ssrole.ToString());
            //int id = int.Parse(ssid.ToString());
            //if (role != 1)
            //{
            //    IDNhanVien = id;
            //}
            if (NgayStart == null)
            {
                NgayStart = "";
            }
            if (NgayStop == null)
            {
                NgayStop = "";
            }
            if (strInforA == null)
            {
                strInforA = "";
            }
            if (strInforB == null)
            {
                strInforB = "";
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
            List<CongChungGet> result = _obj.CongChung_GetNew(count, role, id);
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
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }

        // Sử dụng XlsIO
        //public void CreateDocument()
        //{
        //    using (ExcelEngine excelEngine = new ExcelEngine())
        //    {
        //        excelEngine.Excel.DefaultVersion = ExcelVersion.Excel97to2003;
        //        IWorkbook workbook = excelEngine.Excel.Workbooks.Create(1);
        //        IWorksheet worksheet = workbook.Worksheets[0];
        //        worksheet.Range["A1"].Text = "Hello World";
        //        worksheet.Range["A1"].WrapText = true;
        //        worksheet.Range["A2"].Text = "Hello World2";
        //        workbook.SaveAs("Sample.xlsx", ExcelSaveType.SaveAsXLS, HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
        //    }
        //}

        //Sử dụng aspose
        //public ActionResult CreateDocument()
        //{
        //    //string dataDir = Server.MapPath("ExportExcel");
        //    //string filePath = dataDir + "Sample.xlsx";

        //    SaveType saveType = SaveType.OpenInBrowser;
        //    FileFormatType fft = FileFormatType.Excel2007Xlsx;

        //    string filename = "Sample.xlsx";

        //    Workbook wb = new Workbook();
        //    Worksheet sheet = wb.Worksheets[0];
        //    Cell cell = sheet.Cells["A1"];
        //    cell.PutValue("Hello World!");
        //    wb.Save(filename, saveType, fft, HttpContext.ApplicationInstance.Response);
        //    //wb.Save(filename);
        //    return Json(filename, JsonRequestBehavior.AllowGet);
        //}

        private void DeleteFile(string path)
        {
            string[] filename = Directory.GetFiles(path);
            foreach (string file in filename)
            {
                if (System.IO.File.Exists(file) == true)
                {
                    System.IO.File.Delete(file);
                }
            }
        }
        [HttpGet]

        public ActionResult CreateDocument(string NgayStart, string NgayStop, string strInforA, string strInforB, int IDType,
                    string strContent, int PhiCongChung, int PhiHoaHong, int IDKhachHang, int IDCongChungVien, int IDNhanVien,
                     bool isInforA, bool isInforB, bool isContentCongChung, bool isPhiCongChung,
                    bool isPhiHoaHong, bool isIDType, bool isIDNhanVien, bool isIDCongChungVien, bool isIDKhachHang)
        {
            try
            {
                if (NgayStart == null)
                {
                    NgayStart = "";
                }
                if (NgayStop == null)
                {
                    NgayStop = "";
                }
                if (strInforA == null)
                {
                    strInforA = "";
                }
                if (strInforB == null)
                {
                    strInforB = "";
                }
                List<CongChungGet> result = _obj.CongChung_GetList(NgayStart, NgayStop, strInforA, strInforB, IDType, strContent,
                                                                PhiCongChung, PhiHoaHong, IDKhachHang, IDCongChungVien, IDNhanVien);
                DataTable dt = new DataTable();

                dt.Columns.Add("STT", typeof(int));
                //dt.Columns.Add("Ngày công chứng", typeof(DateTime));
                dt.Columns.Add("Ngày công chứng", typeof(string));
                
                    dt.Columns.Add("Thông tin bên A");
                    dt.Columns.Add("Thông tin bên B");
                    dt.Columns.Add("Loại công chứng");
                    dt.Columns.Add("Nội dung công chứng");
                    dt.Columns.Add("Phí công chứng", typeof(double));
                    dt.Columns.Add("Phí hoa hồng", typeof(double));
                    dt.Columns.Add("Nhân viên thực hiện");
                    dt.Columns.Add("Công chứng viên ký");
                    dt.Columns.Add("Khách hàng");

                if (result.Count > 0)
                {
                    for(var i=0; i<result.Count; i++)
                    {
                        DataRow workRow = dt.NewRow();
                        workRow["STT"] = i + 1;
                        var str = result[i].NgayTao.ToString("dd/MM/yyyy");
                        workRow["Ngày công chứng"] = str;
                        workRow["Thông tin bên A"] = result[i].InforA;
                        workRow["Thông tin bên B"] = result[i].InforB;
                        workRow["Loại công chứng"] = result[i].TypeCC;
                        workRow["Nội dung công chứng"] = result[i].ContentCongChung;
                        workRow["Phí công chứng"] = result[i].PhiCongChung;
                        workRow["Phí hoa hồng"] = result[i].PhiHoaHong;
                        workRow["Nhân viên thực hiện"] = result[i].FullName;
                        workRow["Công chứng viên ký"] = result[i].FullNameCCV;
                        workRow["Khách hàng"] = result[i].TenKhachHang;
                        dt.Rows.Add(workRow);
                    }
                }
                string tempfile = Server.MapPath("~/Exports/Templates/TemplateCC.xlsx");
                //string filename = "BCCongChung" + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + ".xlsx";
                string filename = "BCCongChung.xlsx";
                string foldername = "/Exports/Files/";
                DeleteFile(Server.MapPath(foldername));
                if (!Directory.Exists(foldername))
                {
                    Directory.CreateDirectory(foldername);
                }

                string savefile = Server.MapPath(foldername) + filename;
                Workbook wb = new Workbook();
                wb.Open(tempfile);
                Worksheet ws = wb.Worksheets[0];
                //Cell cell = ws.Cells["A1"];
                ws.Cells.ImportDataTable(dt, false, 1, 0);
                //cell.PutValue("Hello World!");

                if (!isInforA)
                {
                    ws.Cells.HideColumn(2);
                }
                if (!isInforB)
                {
                    ws.Cells.HideColumn(3);
                }
                if (!isIDType)
                {
                    ws.Cells.HideColumn(4);
                }
                if (!isContentCongChung)
                {
                    ws.Cells.HideColumn(5);
                }
                if (!isPhiCongChung)
                {
                    ws.Cells.HideColumn(6);
                }
                if (!isPhiHoaHong)
                {
                    ws.Cells.HideColumn(7);
                }
                if (!isIDNhanVien)
                {
                    ws.Cells.HideColumn(8);
                }
                if (!isIDCongChungVien)
                {
                    ws.Cells.HideColumn(9);
                }
                if (!isIDKhachHang)
                {
                    ws.Cells.HideColumn(10);
                }


                wb.Save(savefile);
                return Json(foldername + filename, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
    }
}
    