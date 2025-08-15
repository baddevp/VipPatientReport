using VipPatientReport.Models.M0301;

namespace VipPatientReport.Services.S0301.I0301;

public interface I0301BenhNhanVip
{
    Task<(bool Success, string Message, object Data, object DoanhNghiep, int TotalRecords, int TotalPages, int CurrentPage)>
    FilterByDayAsync(string tuNgay, string denNgay, int IDChiNhanh, int page = 1, int pageSize = 10);
    Task<byte[]> ExportBaoCaoGoiKhamPdfAsync(M0301ExportRequest request, ISession session);

    Task<byte[]> ExportBaoCaoGoiKhamExcelAsync(M0301ExportRequest request, ISession session);
}

