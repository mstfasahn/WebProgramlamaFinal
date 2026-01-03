using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class RoleService(ApplicationDbContext dbContext) : IRoleService
    {
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await dbContext.Roles.ToListAsync();
            return roles;
        }
    }
}
