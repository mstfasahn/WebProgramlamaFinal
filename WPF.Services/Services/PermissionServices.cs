using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.EndpointDtos;
using WPF.Models.Dtos.PermissionDtos;
using WPF.Models.Dtos.Role;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class PermissionServices(
        ApplicationDbContext dbContext,
        IMapper mapper,
        IRoleService roleService,
        IEndpointServices endpointServices) : IPermissionServices
    {
        public async Task<(IEnumerable<GetEndpointDto> Endpoints, IEnumerable<GetRoleDto> Roles, IEnumerable<GetPermissionDto> Permissions)> GetPermissionDataAsync()
        {
            var endpoints = await endpointServices.GetEndpointsWIncludesAsync();
            var roles = await roleService.GetRolesAsync();
            var permissions = await dbContext.Permissions.ToListAsync();

            return (
                mapper.Map<IEnumerable<GetEndpointDto>>(endpoints),
                mapper.Map<IEnumerable<GetRoleDto>>(roles),
                mapper.Map<IEnumerable<GetPermissionDto>>(permissions)
            );
        }
        public async Task<bool> UpdatePermissionAsync(int roleId, int endpointId, bool isActive)
        {
            if (roleId == 1) return false; // Admin korumasý

            var permission = await dbContext.Permissions
                .FirstOrDefaultAsync(p => p.RoleId == roleId && p.EndpointId == endpointId);

            if (permission != null)
            {
                permission.IsActive = isActive;
            }
            else
            {
                await dbContext.Permissions.AddAsync(new Permission
                {
                    RoleId = roleId,
                    EndpointId = endpointId,
                    IsActive = isActive
                });
            }

            return await dbContext.SaveChangesAsync()>=0;
             
        }
    }
}
