﻿using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class UserManagerRepository : IUserManagerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserManagerRepository(ApplicationDbContext context, UserManager<SystemUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserToRoleAsync(SystemUser user, string role)
        {
            var result = await _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public async Task<bool> AssignRoleToUser(string email, string roleName)
        {
            var result = await _context.systemUsers.FirstOrDefaultAsync(u => u.Email == email);
            if(result != null)
            {
                if(! await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
                await AddUserToRoleAsync(result, roleName);

                return true;
            }
            return false;
        }

        public async Task<bool> CheckUserPasswordAsync(SystemUser user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task<IdentityResult> ConfirmUserEmailAsync(SystemUser user, string token)
        {
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return result;
        }

        public async Task<IdentityResult> CreateUserAsync(SystemUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<SystemUser> FindUserByEmailAsync(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            return result;
        }

        public async Task<SystemUser> FindUserByIdAsync(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);
            return result;
        }

        public Task<SystemUser> FindUserByNameAsync(string userName)
        {
            var result = _userManager.FindByNameAsync(userName);
            return result;
        }

        public async Task<string> GenerateUserEmailConfirmationTokenAsync(SystemUser user)
        {
            var result = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return result;
        }

        public async Task<IList<string>> GetUserRolesAsync(SystemUser user)
        {
            var result = await _userManager.GetRolesAsync(user);
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(SystemUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result;
        }
    }
}
