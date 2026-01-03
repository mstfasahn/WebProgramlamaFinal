using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Data;
using WPF.Models.Constants;
using WPF.Models.Dtos.User;
using WPF.Models.Dtos.UserDtos;
using WPF.Models.Entities;
using WPF.Services.Contracts;

namespace WPF.Services.Services
{
    public class UserService(ApplicationDbContext dbContext, IMapper mapper) : IUserService
    {

        public async Task<UserProfileDto> GetUserByIdForProfileAsync(int id)
        {
            var user = await dbContext.Users
                .Include(x=>x.Role)
                .Include(x=>x.State)
                .ThenInclude(x=>x.City)
                .ThenInclude(x=>x.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) { return null; }
            return mapper.Map<UserProfileDto>(user);
        }

        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var user = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) { return null; }
            return mapper.Map<GetUserDto>(user);
        }
        public async Task<GetUserDto> UpdateUserAsync(UpdateUserDto dto, int currentSessionUserId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            //Oturumu açan kiþi ile güncellenen kiþi ayný mý?
            // Eðer admin yetkisi yoksa, sadece kendi ID'sini güncelleyebilmeli.
            if (dto.Id != currentSessionUserId)
            {
                throw new UnauthorizedAccessException("Baþka bir kullanýcýnýn bilgilerini güncelleyemezsiniz.");
            }

            var userInDb = await dbContext.Users.FindAsync(dto.Id);
            if (userInDb == null) return null;

            mapper.Map(dto, userInDb);
            await dbContext.SaveChangesAsync();

            return mapper.Map<GetUserDto>(userInDb);
        }

        public async Task<bool> DeleteUser(int id, int currentSessionUserId)
        {


            var DeleteUser = await dbContext.Users.FindAsync(id);
            var ProccessUser = await dbContext.Users.FindAsync(currentSessionUserId);
            if (DeleteUser == null || ProccessUser ==null )  throw new UnauthorizedAccessException("Geçersiz Ýþlem."); ;

            //Sadece kendi hesabýný silebilir ya da admin silebilir.
            if (DeleteUser.Id != ProccessUser.Id || ProccessUser.RoleId!=(int)UserRole.Admin)
            {
                throw new UnauthorizedAccessException("Baþka bir hesabý silme yetkiniz yok.");
            }
            dbContext.Users.Remove(DeleteUser);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllUserWithRoles()
        {
            var users= await dbContext.Users
                .Include(u=>u.Role)
                .Include(u=>u.State)
                .ThenInclude(s=>s.City)
                .ThenInclude(s=>s.Country)
                .ToListAsync();

            return users;
        }

        public async Task<bool> IsAValidRequest(int userId,int roleId)
        {
            var user= await dbContext.Users.FindAsync(userId);
            if (user == null) return false;
            if(roleId != user.RoleId) return false;
            return true;
        }
    }
}
