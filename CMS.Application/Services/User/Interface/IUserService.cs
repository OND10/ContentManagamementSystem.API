using CMS.Application.Common.Handling;
using CMS.Application.DTOs.UserDtos.Request;
using CMS.Application.DTOs.UserDtos.Response;
using CMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.User.Interface
{
    public interface IUserService
    {
        Task<Result<LoginResponseDto>> Login(LoginRequestDto request);
        Task<Result<UserResponseDto>> Register(RegisterRequestDto request);
        Task<Result<bool>> AddUserToRole(UserRoleRequestDto request);
        Task<Result<string>> GenerateUserEmailConfirmationTokenAsync(SystemUser user);
        Task<Result<SystemUser>> FindUserByIdAsync(string userId);
        Task<Result<IdentityResult>> ConfirmUserEmailAsync(SystemUser user, string token);
        Task<Result<SystemUser>> FindUserByUsernameAsync(string username);
        Task<Result<IEnumerable<string>>> GetUserRolesAsync(SystemUser user);
        Task<Result<RefreshTokenResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto request);

    }
}
