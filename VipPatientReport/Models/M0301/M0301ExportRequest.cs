namespace VipPatientReport.Models.M0301
{
    public class M0301ExportRequest
    {
        public List<M0301BenhNhanVip> Data { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public M0301ThongTinDoanhNghiep DoanhNghiep { get; set; }
    }
}
