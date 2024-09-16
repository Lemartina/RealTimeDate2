
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RealTImeDate2.Data;
using RealTImeDate2.Hubs;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace RealTImeDate2.Services
{
    public class EmployeeServices
    {
        private readonly IHubContext<EmployeeHub> _context;
        AppDbContext dbContext = new AppDbContext();
        private readonly SqlTableDependency<Employee> _dependency;
        private readonly string _connectionString;

        public EmployeeServices(IHubContext<EmployeeHub> context)

        {
            _context=context;

            _connectionString = "Server=LAPTOP-17F35AKM\\SQLEXPRESS;Database=CompanyDatabase2;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true";
            _dependency = new SqlTableDependency<Employee>(_connectionString, "Employee");
            _dependency.OnChanged += Changed;
           _dependency.Start();
        }

        private async void Changed(object sender, RecordChangedEventArgs<Employee> e)
        {
           var employees =await GetAllEmployees();
            await _context.Clients.All.SendAsync("RefreshEmployees", employees);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await dbContext.Employee.AsNoTracking().ToListAsync  ();
        }
    }
}
