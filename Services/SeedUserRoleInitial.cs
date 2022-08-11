using Microsoft.AspNetCore.Identity;

namespace ReryFood.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("teste@teste.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "teste@teste.com";
                user.Email = "teste@teste.com";
                user.NormalizedUserName = "TESTE@TESTE.COM";
                user.NormalizedEmail = "TESTE@TESTE.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "numSey@1999").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Member").Wait();
            }
            if (_userManager.FindByEmailAsync("admin@teste.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@teste.com";
                user.Email = "admin@teste.com";
                user.NormalizedUserName = "ADMIN@TESTE.COM";
                user.NormalizedEmail = "ADMIN@TESTE.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "numSey@1999").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}
