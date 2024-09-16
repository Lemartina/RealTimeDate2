
using Microsoft.EntityFrameworkCore;
using RealTImeDate2.Data;
namespace RealTImeDate2.Services
{
    public class EmployeeServices
    {
        AppDbContext dbContext = new AppDbContext();

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await dbContext.Employee.AsNoTracking().ToListAsync  ();
        }
    }
}
