using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VipPatientReport.Migrations
{
    /// <inheritdoc />
    public partial class InitFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Tien_Mau1",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaYTe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaTiepNhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NamSinh = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PASSPORT = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QuocTich = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenChuyenGia = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GoiKham = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhongKham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThoiGianTiepNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiTiepNhan = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false),
                    IdChiNhanh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tien_Mau1", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tien_Mau1",
                columns: new[] { "Id", "CCCD", "GioiTinh", "GoiKham", "HoTen", "IdChiNhanh", "MaTiepNhan", "MaYTe", "NamSinh", "NguoiTiepNhan", "PASSPORT", "PhongKham", "QuocTich", "TenChuyenGia", "ThoiGianTiepNhan", "TrangThai" },
                values: new object[,]
                {
                    { 1L, "07941778421", "Nữ", "VIP-1", "Lê Văn Cường", 1, "MTN0001", "MYT0001", 1989, "NV004", "P5534812", "PK102", "Việt Nam", "GS. D", new DateTime(2025, 8, 8, 14, 27, 0, 0, DateTimeKind.Local), true },
                    { 2L, "07968937788", "Nữ", "VIP-1", "Hoàng Văn Inh", 2, "MTN0002", "MYT0002", 1979, "NV005", "P3043433", "PK202", "Việt Nam", "BS. B", new DateTime(2025, 8, 12, 11, 29, 0, 0, DateTimeKind.Local), false },
                    { 3L, "07957020252", "Nữ", "VIP-1", "Đặng Văn Hoa", 1, "MTN0003", "MYT0003", 2000, "NV001", "P4939653", "PK202", "Việt Nam", "BS. B", new DateTime(2025, 7, 22, 15, 35, 0, 0, DateTimeKind.Local), false },
                    { 4L, "07987786202", "Nam", "VIP-1", "Trần Văn Kim", 2, "MTN0004", "MYT0004", 1992, "NV004", "P7059616", "PK101", "Việt Nam", "BS. B", new DateTime(2025, 7, 29, 7, 17, 0, 0, DateTimeKind.Local), true },
                    { 5L, "07961262825", "Nữ", "VIP-3", "Bùi Văn Em", 1, "MTN0005", "MYT0005", 1995, "NV002", "P3003631", "PK202", "Việt Nam", "BS. B", new DateTime(2025, 7, 27, 11, 14, 0, 0, DateTimeKind.Local), true },
                    { 6L, "07981684565", "Nữ", "VIP-3", "Vũ Văn Kim", 2, "MTN0006", "MYT0006", 1971, "NV003", "P9082703", "PK202", "Việt Nam", "BS. A", new DateTime(2025, 8, 4, 14, 18, 0, 0, DateTimeKind.Local), false },
                    { 7L, "07970936003", "Nam", "VIP-2", "Đặng Văn Hoa", 1, "MTN0007", "MYT0007", 1972, "NV005", "P8177742", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 7, 29, 12, 5, 0, 0, DateTimeKind.Local), false },
                    { 8L, "07999992295", "Nam", "VIP-3", "Nguyễn Văn Giang", 2, "MTN0008", "MYT0008", 1969, "NV001", "P1192776", "PK101", "Việt Nam", "BS. C", new DateTime(2025, 8, 6, 10, 55, 0, 0, DateTimeKind.Local), true },
                    { 9L, "07985394881", "Nữ", "VIP-3", "Hoàng Văn Dung", 1, "MTN0009", "MYT0009", 1999, "NV001", "P7936903", "PK201", "Việt Nam", "BS. B", new DateTime(2025, 7, 21, 11, 24, 0, 0, DateTimeKind.Local), true },
                    { 10L, "07969148815", "Nữ", "VIP-3", "Đặng Văn Phương", 2, "MTN0010", "MYT0010", 2000, "NV002", "P8164908", "PK102", "Việt Nam", "BS. B", new DateTime(2025, 8, 8, 7, 44, 0, 0, DateTimeKind.Local), false },
                    { 11L, "07932483656", "Nữ", "VIP-3", "Đặng Văn Inh", 1, "MTN0011", "MYT0011", 1976, "NV005", "P8463011", "PK102", "Việt Nam", "BS. A", new DateTime(2025, 7, 20, 7, 42, 0, 0, DateTimeKind.Local), false },
                    { 12L, "07936205692", "Nam", "VIP-2", "Nguyễn Văn Bình", 2, "MTN0012", "MYT0012", 1981, "NV002", "P4119342", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 8, 1, 11, 55, 0, 0, DateTimeKind.Local), false },
                    { 13L, "07981122712", "Nam", "VIP-3", "Nguyễn Văn Em", 1, "MTN0013", "MYT0013", 1994, "NV004", "P4683604", "PK102", "Việt Nam", "GS. D", new DateTime(2025, 7, 27, 7, 3, 0, 0, DateTimeKind.Local), true },
                    { 14L, "07979655503", "Nam", "VIP-2", "Lê Văn Bình", 2, "MTN0014", "MYT0014", 2001, "NV001", "P9214371", "PK102", "Việt Nam", "BS. B", new DateTime(2025, 8, 8, 10, 57, 0, 0, DateTimeKind.Local), false },
                    { 15L, "07944975597", "Nam", "VIP-1", "Võ Văn Em", 1, "MTN0015", "MYT0015", 1989, "NV005", "P4921478", "PK202", "Việt Nam", "GS. D", new DateTime(2025, 7, 26, 11, 24, 0, 0, DateTimeKind.Local), true },
                    { 16L, "07925637824", "Nữ", "VIP-1", "Hoàng Văn Dung", 2, "MTN0016", "MYT0016", 1988, "NV001", "P5201121", "PK101", "Việt Nam", "GS. D", new DateTime(2025, 7, 27, 12, 17, 0, 0, DateTimeKind.Local), true },
                    { 17L, "07930980729", "Nam", "VIP-3", "Hoàng Văn Bình", 1, "MTN0017", "MYT0017", 1984, "NV001", "P2862819", "PK101", "Việt Nam", "BS. B", new DateTime(2025, 7, 26, 14, 54, 0, 0, DateTimeKind.Local), true },
                    { 18L, "07938852846", "Nam", "VIP-1", "Vũ Văn Bình", 2, "MTN0018", "MYT0018", 1993, "NV004", "P8509029", "PK201", "Việt Nam", "GS. D", new DateTime(2025, 8, 13, 8, 19, 0, 0, DateTimeKind.Local), false },
                    { 19L, "07933715035", "Nữ", "VIP-3", "Vũ Văn Inh", 1, "MTN0019", "MYT0019", 1992, "NV003", "P2185979", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 8, 10, 9, 35, 0, 0, DateTimeKind.Local), false },
                    { 20L, "07914692435", "Nam", "VIP-3", "Bùi Văn Em", 2, "MTN0020", "MYT0020", 1977, "NV005", "P9425542", "PK201", "Việt Nam", "BS. A", new DateTime(2025, 7, 26, 8, 22, 0, 0, DateTimeKind.Local), false },
                    { 21L, "07958899935", "Nữ", "VIP-2", "Võ Văn Phương", 1, "MTN0021", "MYT0021", 1975, "NV004", "P2808506", "PK201", "Việt Nam", "BS. C", new DateTime(2025, 7, 26, 9, 43, 0, 0, DateTimeKind.Local), false },
                    { 22L, "07962555075", "Nam", "VIP-1", "Đặng Văn Kim", 2, "MTN0022", "MYT0022", 1973, "NV001", "P2685513", "PK202", "Việt Nam", "GS. D", new DateTime(2025, 8, 6, 15, 59, 0, 0, DateTimeKind.Local), true },
                    { 23L, "07937920079", "Nam", "VIP-3", "Võ Văn Kim", 1, "MTN0023", "MYT0023", 1993, "NV005", "P9475950", "PK202", "Việt Nam", "BS. C", new DateTime(2025, 8, 2, 7, 42, 0, 0, DateTimeKind.Local), true },
                    { 24L, "07952981771", "Nữ", "VIP-2", "Đinh Văn Hoa", 2, "MTN0024", "MYT0024", 1962, "NV002", "P8633214", "PK101", "Việt Nam", "BS. A", new DateTime(2025, 7, 28, 14, 13, 0, 0, DateTimeKind.Local), true },
                    { 25L, "07926088889", "Nữ", "VIP-3", "Bùi Văn Inh", 1, "MTN0025", "MYT0025", 1989, "NV003", "P3351942", "PK202", "Việt Nam", "BS. B", new DateTime(2025, 8, 14, 16, 40, 0, 0, DateTimeKind.Local), true },
                    { 26L, "07929966675", "Nữ", "VIP-2", "Nguyễn Văn Phương", 2, "MTN0026", "MYT0026", 1983, "NV005", "P3956087", "PK101", "Việt Nam", "BS. C", new DateTime(2025, 8, 13, 8, 55, 0, 0, DateTimeKind.Local), false },
                    { 27L, "07928388425", "Nam", "VIP-1", "Trần Văn Giang", 1, "MTN0027", "MYT0027", 1968, "NV001", "P6449548", "PK202", "Việt Nam", "GS. D", new DateTime(2025, 7, 29, 13, 22, 0, 0, DateTimeKind.Local), true },
                    { 28L, "07925477322", "Nam", "VIP-1", "Đặng Văn Kim", 2, "MTN0028", "MYT0028", 1992, "NV002", "P9592753", "PK101", "Việt Nam", "BS. B", new DateTime(2025, 7, 20, 9, 24, 0, 0, DateTimeKind.Local), false },
                    { 29L, "07986660738", "Nam", "VIP-2", "Vũ Văn An", 1, "MTN0029", "MYT0029", 1978, "NV002", "P9313423", "PK102", "Việt Nam", "BS. A", new DateTime(2025, 8, 4, 13, 58, 0, 0, DateTimeKind.Local), false },
                    { 30L, "07929523621", "Nam", "VIP-2", "Võ Văn Phương", 2, "MTN0030", "MYT0030", 1963, "NV002", "P6815352", "PK101", "Việt Nam", "BS. B", new DateTime(2025, 8, 14, 16, 4, 0, 0, DateTimeKind.Local), false },
                    { 31L, "07919769542", "Nam", "VIP-1", "Lê Văn Hoa", 1, "MTN0031", "MYT0031", 1980, "NV005", "P5697183", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 7, 29, 9, 57, 0, 0, DateTimeKind.Local), true },
                    { 32L, "07978364602", "Nữ", "VIP-1", "Võ Văn Bình", 2, "MTN0032", "MYT0032", 1968, "NV005", "P4323146", "PK201", "Việt Nam", "BS. A", new DateTime(2025, 7, 27, 7, 29, 0, 0, DateTimeKind.Local), false },
                    { 33L, "07976789511", "Nữ", "VIP-2", "Nguyễn Văn Dung", 1, "MTN0033", "MYT0033", 1999, "NV003", "P7080740", "PK101", "Việt Nam", "BS. B", new DateTime(2025, 7, 17, 15, 16, 0, 0, DateTimeKind.Local), true },
                    { 34L, "07911890562", "Nam", "VIP-2", "Võ Văn An", 2, "MTN0034", "MYT0034", 1990, "NV005", "P7655434", "PK201", "Việt Nam", "BS. C", new DateTime(2025, 7, 18, 13, 47, 0, 0, DateTimeKind.Local), true },
                    { 35L, "07958190550", "Nam", "VIP-1", "Võ Văn Cường", 1, "MTN0035", "MYT0035", 1997, "NV003", "P6184140", "PK202", "Việt Nam", "BS. A", new DateTime(2025, 8, 12, 10, 22, 0, 0, DateTimeKind.Local), false },
                    { 36L, "07991917547", "Nam", "VIP-3", "Trần Văn An", 2, "MTN0036", "MYT0036", 2003, "NV001", "P3242602", "PK101", "Việt Nam", "BS. C", new DateTime(2025, 7, 27, 11, 7, 0, 0, DateTimeKind.Local), true },
                    { 37L, "07936171267", "Nam", "VIP-2", "Đặng Văn Kim", 1, "MTN0037", "MYT0037", 1971, "NV004", "P3885682", "PK202", "Việt Nam", "BS. A", new DateTime(2025, 8, 6, 13, 6, 0, 0, DateTimeKind.Local), false },
                    { 38L, "07958765793", "Nữ", "VIP-2", "Vũ Văn An", 2, "MTN0038", "MYT0038", 2000, "NV004", "P9929893", "PK202", "Việt Nam", "BS. A", new DateTime(2025, 8, 2, 16, 12, 0, 0, DateTimeKind.Local), true },
                    { 39L, "07929461177", "Nữ", "VIP-3", "Hoàng Văn Cường", 1, "MTN0039", "MYT0039", 1966, "NV003", "P8453487", "PK202", "Việt Nam", "BS. C", new DateTime(2025, 7, 26, 8, 26, 0, 0, DateTimeKind.Local), true },
                    { 40L, "07950334146", "Nữ", "VIP-1", "Đinh Văn An", 2, "MTN0040", "MYT0040", 2000, "NV004", "P1705111", "PK201", "Việt Nam", "GS. D", new DateTime(2025, 7, 21, 9, 26, 0, 0, DateTimeKind.Local), true },
                    { 41L, "07975763098", "Nam", "VIP-2", "Nguyễn Văn Bình", 1, "MTN0041", "MYT0041", 1976, "NV005", "P4497383", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 8, 11, 10, 5, 0, 0, DateTimeKind.Local), true },
                    { 42L, "07946455374", "Nữ", "VIP-1", "Hoàng Văn Giang", 2, "MTN0042", "MYT0042", 2004, "NV005", "P3901036", "PK201", "Việt Nam", "BS. B", new DateTime(2025, 8, 9, 11, 4, 0, 0, DateTimeKind.Local), true },
                    { 43L, "07969151576", "Nữ", "VIP-2", "Vũ Văn Inh", 1, "MTN0043", "MYT0043", 1983, "NV003", "P4791189", "PK102", "Việt Nam", "BS. B", new DateTime(2025, 8, 11, 15, 40, 0, 0, DateTimeKind.Local), false },
                    { 44L, "07928101709", "Nam", "VIP-2", "Phạm Văn Em", 2, "MTN0044", "MYT0044", 1969, "NV001", "P6850937", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 7, 23, 8, 5, 0, 0, DateTimeKind.Local), true },
                    { 45L, "07961565971", "Nữ", "VIP-2", "Hoàng Văn Cường", 1, "MTN0045", "MYT0045", 1999, "NV005", "P4637583", "PK102", "Việt Nam", "BS. C", new DateTime(2025, 8, 14, 11, 9, 0, 0, DateTimeKind.Local), false },
                    { 46L, "07914015557", "Nữ", "VIP-2", "Vũ Văn Cường", 2, "MTN0046", "MYT0046", 1980, "NV002", "P5944033", "PK201", "Việt Nam", "BS. A", new DateTime(2025, 7, 22, 12, 54, 0, 0, DateTimeKind.Local), false },
                    { 47L, "07962916562", "Nữ", "VIP-2", "Bùi Văn Inh", 1, "MTN0047", "MYT0047", 1967, "NV005", "P4667606", "PK101", "Việt Nam", "BS. A", new DateTime(2025, 8, 4, 10, 32, 0, 0, DateTimeKind.Local), true },
                    { 48L, "07990829155", "Nam", "VIP-2", "Trần Văn Hoa", 2, "MTN0048", "MYT0048", 2000, "NV004", "P7897582", "PK201", "Việt Nam", "GS. D", new DateTime(2025, 7, 29, 15, 32, 0, 0, DateTimeKind.Local), true },
                    { 49L, "07986154858", "Nữ", "VIP-3", "Đinh Văn Em", 1, "MTN0049", "MYT0049", 1973, "NV003", "P3378577", "PK202", "Việt Nam", "BS. B", new DateTime(2025, 7, 19, 13, 15, 0, 0, DateTimeKind.Local), true },
                    { 50L, "07947695523", "Nữ", "VIP-3", "Vũ Văn Bình", 2, "MTN0050", "MYT0050", 1975, "NV003", "P6549769", "PK101", "Việt Nam", "BS. C", new DateTime(2025, 8, 7, 15, 35, 0, 0, DateTimeKind.Local), false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tien_Mau1_IdChiNhanh",
                table: "Tien_Mau1",
                column: "IdChiNhanh");

            migrationBuilder.CreateIndex(
                name: "IX_Tien_Mau1_MaTiepNhan",
                table: "Tien_Mau1",
                column: "MaTiepNhan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tien_Mau1_ThoiGianTiepNhan",
                table: "Tien_Mau1",
                column: "ThoiGianTiepNhan");
        }

     
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropTable(
                name: "Tien_Mau1");
        }
    }
}
