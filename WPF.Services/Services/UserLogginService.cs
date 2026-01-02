using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class UserLogginService(ApplicationDbContext dbContext) : IUserLogginService
    {
        public async Task LogAsync(int? userId, string controller, string action, string ip)
        {
            var log = new UserLog
            {
                UserId = userId,
                ControllerName = controller,
                ActionName = action,
                IpAddress = ip,
                LogDate = DateTime.Now
            };
            dbContext.UserLogs.Add(log);
            await dbContext.SaveChangesAsync();
        }
    }
}
