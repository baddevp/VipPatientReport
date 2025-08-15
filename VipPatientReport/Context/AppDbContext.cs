using Microsoft.EntityFrameworkCore;
using VipPatientReport.Models.M0301;

namespace VipPatientReport.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<M0301BenhNhanVip> Tien_Mau01 { get; set; }
        public DbSet<M0301ThongTinDoanhNghiep> ThongTinDoanhNghieps { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<M0301BenhNhanVip>().HasNoKey();
        //    modelBuilder.Entity<M0301ThongTinDoanhNghiep>().HasNoKey();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<M0301BenhNhanVip>(e =>
            {
                e.Property(x => x.Id).UseIdentityColumn(); // auto-increment
                e.HasIndex(x => x.MaTiepNhan).IsUnique();
                e.HasIndex(x => x.ThoiGianTiepNhan);
                e.HasIndex(x => x.IdChiNhanh);
            });

            // Seed 20 records
            var rnd = new Random(2025);
            var ho = new[] { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Vũ", "Võ", "Đặng", "Bùi", "Đinh" };
            var ten = new[] { "An", "Bình", "Cường", "Dung", "Em", "Phương", "Giang", "Hoa", "Inh", "Kim" };
            var chuyenGia = new[] { "BS. A", "BS. B", "BS. C", "GS. D" };
            var goi = new[] { "VIP-1", "VIP-2", "VIP-3" };
            var phong = new[] { "PK101", "PK102", "PK201", "PK202" };
            var list = new List<M0301BenhNhanVip>();

            for (int i = 1; i <= 50; i++)
            {
                var branch = i % 2 == 0 ? 2 : 1;
                var ns = rnd.Next(1960, 2006);
                var gt = rnd.Next(0, 2) == 0 ? "Nam" : "Nữ";
                var now = DateTime.Today.AddDays(-rnd.Next(0, 30)).AddHours(rnd.Next(7, 17)).AddMinutes(rnd.Next(0, 60));
                list.Add(new M0301BenhNhanVip
                {
                    Id = i, // will be identity when inserting new; for seed we set explicit
                    MaYTe = $"MYT{i:0000}",
                    MaTiepNhan = $"MTN{i:0000}",
                    HoTen = $"{ho[rnd.Next(ho.Length)]} Văn {ten[rnd.Next(ten.Length)]}",
                    NamSinh = ns,
                    GioiTinh = gt,
                    CCCD = $"079{rnd.Next(10000000, 99999999)}",
                    PASSPORT = $"P{rnd.Next(1000000, 9999999)}",
                    QuocTich = "Việt Nam",
                    TenChuyenGia = chuyenGia[rnd.Next(chuyenGia.Length)],
                    GoiKham = goi[rnd.Next(goi.Length)],
                    PhongKham = phong[rnd.Next(phong.Length)],
                    ThoiGianTiepNhan = now,
                    NguoiTiepNhan = $"NV{rnd.Next(1, 6):000}",
                    TrangThai = rnd.Next(0, 2) == 1, // true/false
                    IdChiNhanh = branch
                });
            }

            modelBuilder.Entity<M0301BenhNhanVip>().HasData(list);
        }
        public bool TestConnection()
        {
            try
            {
                return this.Database.CanConnect();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
