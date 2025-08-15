using Microsoft.EntityFrameworkCore;
using VipPatientReport.Models.M0301;

namespace VipPatientReport.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<M0301BenhNhanVip> Tien_Mau01 { get; set; }

       // public DbSet<M0301BenhNhanVip> BenhNhanVips { get; set; }
        public DbSet<M0301ThongTinDoanhNghiep> ThongTinDoanhNghieps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<M0301BenhNhanVip>().HasNoKey();
            modelBuilder.Entity<M0301ThongTinDoanhNghiep>().HasNoKey();
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
