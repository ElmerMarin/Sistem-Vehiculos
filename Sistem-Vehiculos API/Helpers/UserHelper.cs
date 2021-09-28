using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sistem_Vehiculos_API.Data;
using Sistem_Vehiculos_API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistem_Vehiculos_API.Models;

namespace Sistem_Vehiculos_API.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;
        private readonly SignInManager<User> _signInManager;

        public UserHelper(UserManager<User> userManager,RoleManager<IdentityRole> roleManager,DataContext context,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user,password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user,roleName);

        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists) 
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }

        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(x => x.documentType)
                .FirstOrDefaultAsync(x=>x.Email==email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string rolename)
        {
            return await _userManager.IsInRoleAsync(user,rolename);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

        }

        public async Task LogoutAsync(LoginViewModel model)
        {
            await _signInManager.SignOutAsync();

        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public Task<User> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
