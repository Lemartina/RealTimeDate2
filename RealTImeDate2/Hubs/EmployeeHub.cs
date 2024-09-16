using Microsoft.AspNetCore.SignalR;
using RealTImeDate2.Data;

namespace RealTImeDate2.Hubs
{
    public class EmployeeHub : Hub
    {
        public async Task RefresfEmployees(List<Employee> employees)
        {
            await Clients.All.SendAsync("RefresfEmployees", employees);
        }
    }
}
