using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WPF.Data;
using WPF.Models.Dtos.User;
using WPF.Models.Entities;
using WPF.Services.Contracts;


namespace WPF.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserDto?> LoginAsync(UserLoginDto loginDto)
        {
            // 1. Kullanýcýyý Email ile bul ve Rol bilgisini Include et
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email && u.PasswordHash == loginDto.Password);

            if (user == null) return null;

            // 2. AutoMapper ile DTO'ya çevir (RoleName'in eþleþtiðinden emin ol)
            return _mapper.Map<GetUserDto>(user);
        }

        public async Task RegisterAsync(UserRegisterDto registerDto)
        {
            // Email kontrolü
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
                return ;

            var user = _mapper.Map<User>(registerDto);

            // Varsayýlan bir rol atayalým
            user.RoleId = 2;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return;
        }

        public Task LogoutAsync()
        {

            // Session temizliði Controller tarafýnda yapýlacak
            return Task.CompletedTask;
        }
    }
}