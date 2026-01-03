using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Entities;
using WPF.Services.Contracts;
namespace WPF.Services.Services
{
    public class EndpointServices(ApplicationDbContext _dbContext) : IEndpointServices
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
                    var exists = await _dbContext.Endpoints.AnyAsync(e =>
                        e.ControllerName == controllerName && e.ActionName == actionName);

                    if (!exists)
                    {
                        _dbContext.Endpoints.Add(new Endpoint
                        {
                            ControllerName = controllerName,
                            ActionName = actionName
                        });
                    }
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}