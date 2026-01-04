using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Dtos.EndpointDtos;
using WPF.Models.Entities;
using WPF.Services.Contracts;
namespace WPF.Services.Services
{
    public class EndpointServices(ApplicationDbContext dbContext,IMapper mapper) : IEndpointServices
    {
        public async Task SeedEndpointsAsync(Assembly webAssembly)
        {
            // Dýþarýdan gelen assembly'deki tipleri tara
            var controllerTypes = webAssembly.GetTypes()
                .Where(type => (typeof(Controller).IsAssignableFrom(type) ||
                                typeof(ControllerBase).IsAssignableFrom(type)) &&
                               !type.IsAbstract);

            foreach (var controller in controllerTypes)
            {
                var controllerName = controller.Name.Replace("Controller", "");

                // Sadece public ve senin yazdýðýn action'larý al
                var actions = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any());

                foreach (var action in actions)
                {
                    var actionName = action.Name;
                    var exists = await dbContext.Endpoints.AnyAsync(e =>
                        e.ControllerName == controllerName && e.ActionName == actionName);

                    if (!exists)
                    {
                        dbContext.Endpoints.Add(new Endpoint
                        {
                            ControllerName = controllerName,
                            ActionName = actionName
                        });
                    }
                }
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListEndpointDto>> GetEndpointsWIncludesAsync()
        {
            var endpoints= await dbContext.Endpoints.Include(e=>e.Permissions).ToListAsync();
            var listEndpointDto = mapper.Map<IEnumerable<ListEndpointDto>>(endpoints); 
            return listEndpointDto;
        }
        public async Task<IEnumerable<GetEndpointDto>> GetEndpointsAsync()
        {
            var endpoints = await dbContext.Endpoints.Include(e => e.Permissions).ToListAsync();
            var endpointList = mapper.Map<IEnumerable<GetEndpointDto>>(endpoints);
            return endpointList;
        }
    }
}