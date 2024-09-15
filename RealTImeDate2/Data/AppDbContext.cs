using Microsoft.EntityFrameworkCore;

namespace RealTImeDate2.Data
{
    public class AppDbContext : DbContext
    { 
    //POVEZANO S BAZOM I RADI
        string _connectionString = "Server=LAPTOP-17F35AKM\\SQLEXPRESS;Database=CompanyDatabase2;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true";

        
        public DbSet<Employee> Employee {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        
            
    }
}
