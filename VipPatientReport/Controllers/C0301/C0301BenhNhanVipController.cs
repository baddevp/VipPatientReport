using Microsoft.AspNetCore.Mvc;
using VipPatientReport.Models.M0301;
using VipPatientReport.Services.S0301.I0301;

namespace VipPatientReport.Controllers.C0301
{
    [Route("benhnhanvip")]
    public class C0301BenhNhanVipController : Controller
    {
        //private string _maChucNang = "benhnhanvip";
        //private IMemoryCachingServices _memoryCache;


        private readonly I0301BenhNhanVip _service;
        
        public C0301BenhNhanVipController(I0301BenhNhanVip service /*, IMemoryCachingServices memoryCache*/)
        {
            _service = service;

            //_memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            /*
            var quyenVaiTro = await _memoryCache.getQuyenVaiTro(_maChucNang);
            if(quyenVaiTro == null){
                return RedirectToAction("NotFound", "Home");
            }
            ViewBag.quyenVaiTro = quyenVaiTro;
            ViewData["Title"] = CommonServices.toEmptyData(quyenVaiTro);
             */
            ViewBag.quyenVaiTro = new
            {
                Them = true,
                Xoa = true,
                Sua = true,
                Xuat = true,
                CaNhan = true,
                Xem = true
            };
            return View("~/Views/V0301/V0301BenhNhanVip/Index.cshtml");
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterByDay(string tuNgay, string denNgay, int IdChiNhanh, int page = 1, int pageSize = 10)
        {
            var result = await _service.FilterByDayAsync(tuNgay, denNgay, IdChiNhanh, page, pageSize);

            if (!result.Success)
            {
                return Json(new { success = false, message = result.Message });
            }

            return Json(new
            {
                success = true,
                message = result.Message,
                data = result.Data,
                totalRecords = result.TotalRecords,
                totalPages = result.TotalPages,
                currentPage = result.CurrentPage,
                doanhNghiep = result.DoanhNghiep
            });
        }
        [HttpPost("export/pdf")]
        public async Task<IActionResult> ExportToPDF([FromBody] M0301ExportRequest request)
        {
            var pdfBytes = await _service.ExportThongKeBenhNhanVipPdfAsync(request, HttpContext.Session);

            string fileName = $"ThongKeBenhNhanVip_{request.FromDate ?? "all"}_den_{request.ToDate ?? "now"}.pdf";
            return File(pdfBytes, "application/pdf", fileName);
        }

        [HttpPost("export/excel")]
        public async Task<IActionResult> ExportToExcel([FromBody] M0301ExportRequest request)
        {
            var excelBytes = await _service.ExportThongKeBenhNhanVipExcelAsync(request, HttpContext.Session);

            string fileName = $"ThongKeBenhNhanVip_{request.FromDate ?? "all"}_den_{request.ToDate ?? "now"}.xlsx";
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }

}
