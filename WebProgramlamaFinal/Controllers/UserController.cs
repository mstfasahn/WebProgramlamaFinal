using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WPF.Models.Dtos.MappingProfiles;
using WPF.Models.Dtos.User;
using WPF.MVC.ViewModels;
using WPF.Services.Contracts;
using WPF.Services.Implementations;

namespace WPF.MVC.Controllers
{
    public class UserController
        (IAuthService authService,IUserService userService,IMapper mapper,ICountryService countryService, IRoleService roleService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login", "User");

            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            
            var user = await userService.GetUserByIdAsync(currentUser.Id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            if (!ModelState.IsValid) return View(loginDto);

            var userDto = await authService.LoginAsync(loginDto);

            if (userDto != null)
            {
                // Nesneyi JSON string'e çevirip Session'a atýyoruz
                var userJson = System.Text.Json.JsonSerializer.Serialize(userDto);
                HttpContext.Session.SetString("CurrentUser", userJson);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "E-posta veya þifre hatalý.");
            return View(loginDto);
        }

        [HttpGet]
        public IActionResult Register() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            if (!ModelState.IsValid) 
            {
                return View(dto);
            }
            
            await authService.RegisterAsync(dto);

        // Mesajý TempData ile gönderiyoruz, View'a model olarak deðil!
        TempData["success"] = "Kayýt baþarýyla tamamlandý. Giriþ yapabilirsiniz.";
        return RedirectToAction("Login","User"); // Login sayfasýna temiz bir yönlendirme
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // 1. Session'dan login olan kullanýcýyý al
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login", "User");
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);
            //2. Id'ler uyuþmazsa reddet
            if (id != 0 && id != currentUser.Id)
            {
                return RedirectToAction("AccessDenied", "User");
            }

            // 3. Veriyi getir (id 0 ise kendi profilini getirir)
            int targetId = id == 0 ? currentUser.Id : id;
            var userProfile = await userService.GetUserByIdForProfileAsync(targetId);
            var countries = await countryService.GetCountriesAsync();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");

            return View(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserDto dto)
        {
            // Session'dan mevcut kullanýcýyý al
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson)) return RedirectToAction("Login","User");

            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            try
            {
                // Servise hem DTO'yu hem de session'daki ID'yi gönderiyoruz
                var result = await userService.UpdateUserAsync(dto, currentUser.Id);

                // Eðer baþarýlýysa Session'daki bilgileri de güncelledik
                 HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(result));

                return RedirectToAction("Profile","User");
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("AccessDenied", "User");
            }
        }
        
        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userJson = HttpContext.Session.GetString("CurrentUser");
            if (string.IsNullOrEmpty(userJson))
            {
                return RedirectToAction("Login", "User");
            }
            if (id <= 0)
            {
                TempData["error"] = "Geçersiz kullanýcý ID'si.";
                return RedirectToAction("AccessDenied", "User");
            }
            var currentUser = JsonConvert.DeserializeObject<GetUserDto>(userJson);

            var result =await userService.DeleteUser(id, currentUser.Id);
            if (result)
            {
                // Kendi hesabýný sildiyse session'ý temizle ve çýkýþ yaptýr
                HttpContext.Session.Clear();
                return RedirectToAction("Register", "User");
            }
            return RedirectToAction("Profile", "User"); 
        }

        [HttpGet]
        public async Task<IActionResult> List(string? nameSearch, string? emailSearch, int? roleId) 
        {
            var users =await userService.GetAllUserWithRoles();
            if (!string.IsNullOrEmpty(nameSearch))
                users = users.Where(u => u.Name.Contains(nameSearch, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(emailSearch))
                users = users.Where(u => u.Email.Contains(emailSearch, StringComparison.OrdinalIgnoreCase));

            if (roleId.HasValue)
                users = users.Where(u => u.RoleId == roleId);

            var roles = await roleService.GetRoles();

            ListUserVM ListVM = new ListUserVM
            {
                Users = users,
                NameSearch = null,
                EmailSearch = null,
                SelectedRoleId = roleId,
                Roles = roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected=x.Id ==roleId
                })
            };
            return View(ListVM); 
        }
    }
}
