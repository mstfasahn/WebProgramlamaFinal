using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.Role;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class RoleService(ApplicationDbContext dbContext,IMapper mapper) : IRoleService
    {
        public async Task<IEnumerable<GetRoleDto>> GetRolesAsync()
        {
            var roles = await dbContext.Roles.ToListAsync();
            var rolesDto = mapper.Map<IEnumerable<GetRoleDto>>(roles);
            return rolesDto;
        }
    }
}
