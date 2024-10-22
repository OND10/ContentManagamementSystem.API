﻿using CMS.Application.Common.Handling;
using CMS.Application.DTOs.UserDtos.Request;
using CMS.Application.DTOs.UserDtos.Response;
using CMS.Application.Services.User.Interface;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using OnMapper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.User.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserManagerRepository _repository;
        private readonly ITokenRepository _tokenRepository;
        private readonly OnMapping _mapper;
        private readonly JwtOptions _jwtOptions;
        public UserService(IUserManagerRepository repository, ITokenRepository tokenRepository,
            OnMapping mapper, IOptions<JwtOptions> jwtOptions)
        {
            _repository = repository;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<Result<bool>> AddUserToRole(UserRoleRequestDto request)
        {
            var result = await _repository.AssignRoleToUser(request.Email, request.roleName);
            
            if (result is true)
            {
                return await Result<bool>.SuccessAsync(result, "Role is Created Successfully", true);
            }

            return await Result<bool>.FaildAsync(false, "Role is Created Successfully");
        }

        public async Task<Result<IdentityResult>> ConfirmUserEmailAsync(SystemUser user, string token)
        {
            var result = await _repository.ConfirmUserEmailAsync(user, token);

            return await Result<IdentityResult>.SuccessAsync(result, "Email Confirmed Successfully", true);

        }

        public async Task<Result<SystemUser>> FindUserByIdAsync(string userId)
        {
            var result = await _repository.FindUserByIdAsync(userId);

            return await Result<SystemUser>.SuccessAsync(result, "User is Found Successfully", true);

        }

        public async Task<Result<SystemUser>> FindUserByUsernameAsync(string username)
        {
            var result = await _repository.FindUserByNameAsync(username);
            return await Result<SystemUser>.SuccessAsync(result, "User is Found Successfully", true);
        }

        public async Task<Result<string>> GenerateUserEmailConfirmationTokenAsync(SystemUser user)
        {
            var result = await _repository.GenerateUserEmailConfirmationTokenAsync(user);


            return await Result<string>.SuccessAsync(result, "Email token is Generate Successfully", true);
        }

        public async Task<Result<IEnumerable<string>>> GetUserRolesAsync(SystemUser user)
        {
            return await Result<IEnumerable<string>>.SuccessAsync( await _repository.GetUserRolesAsync(user), ResponseStatus.GetSuccess, true);
        }

        public async Task<Result<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var checkUsernameResult = await _repository.FindUserByNameAsync(request.UserName);

            if (checkUsernameResult is not null)
            {
                //Checking password
                var checkPasswordResult = await _repository.CheckUserPasswordAsync(checkUsernameResult, request.Password);
                
                if (checkPasswordResult)
                {
                    var roles = await _repository.GetUserRolesAsync(checkUsernameResult);

                    //Creating JWT
                    var tokens = _tokenRepository.CreateJWTTokenAsync(checkUsernameResult, roles.ToList());
                    var refreshToken = _tokenRepository.CreateRefreshToken();

                    checkUsernameResult.RefreshToken = refreshToken;
                    checkUsernameResult.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpiration);

                    //Mapping ApplicationUser to the LoginResponseDTO
                    var response = new LoginResponseDto
                    {
                        User = new UserResponseDto
                        {
                            Email = checkUsernameResult.Email,
                            Name = checkUsernameResult.Name,
                            PhoneNumber = checkUsernameResult.PhoneNumber,
                        },
                        Token = tokens,
                        RefreshToken = refreshToken,
                    };
                    return await Result<LoginResponseDto>.SuccessAsync(response, "Logged Successfully", true);
                }
                return await Result<LoginResponseDto>.FaildAsync(false, "Email or Password are incorrect");
            }
            return await Result<LoginResponseDto>.FaildAsync(false, "Email or Password are incorrect");
        }

        public async Task<Result<UserResponseDto>> Register(RegisterRequestDto request)
        {
            var mappedModel = await _mapper.Map<RegisterRequestDto, SystemUser>(request);
            
            mappedModel.Data.Name = request.UserName;

            var result = await _repository.CreateUserAsync(mappedModel.Data, request.Password);

            if (result.Succeeded)
            {
                var checkuserEmailResult = await _repository.FindUserByEmailAsync(request.Email);

                ///
                /// Here I should use mapping but still I am in debugging mode.
                ///
                var userMappedResult = await _mapper.Map<SystemUser, UserResponseDto>(checkuserEmailResult);

                return await Result<UserResponseDto>.SuccessAsync(userMappedResult.Data, "Registered Successfully", true);
            }

            return await Result<UserResponseDto>.FaildAsync(false, $"{result.Errors}");
        }

        public async Task<Result<RefreshTokenResponseDto>> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            if (request == null)
            {
                return await Result<RefreshTokenResponseDto>.FaildAsync(false, "Invalid client request");
            }

            var principal = _tokenRepository.GetPrincipalFromExpiredToken(request.AccessToken);
            var userEmail = principal.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(userEmail))
            {
                return await Result<RefreshTokenResponseDto>.FaildAsync(false, "Invalid client request");
            }

            var user = await _repository.FindUserByEmailAsync(userEmail);
            if (user == null)
            {
                return await Result<RefreshTokenResponseDto>.FaildAsync(false, "User not found");
            }

            if (user.RefreshToken == request.RefreshToken)
            {
                return await Result<RefreshTokenResponseDto>.FaildAsync(false, "Invalid refresh token");
            }

            // Check if refresh token has expired
            if (user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return await Result<RefreshTokenResponseDto>.FaildAsync(false, "Refresh token has expired");
            }
            var roles = await _repository.GetUserRolesAsync(user);
            var newAccessToken = _tokenRepository.CreateJWTTokenAsync(user, roles);
            var newRefreshToken = _tokenRepository.CreateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_jwtOptions.RefreshTokenExpiration);
            await _repository.UpdateAsync(user);

            var response = new RefreshTokenResponseDto(newAccessToken, newRefreshToken);

            return await Result<RefreshTokenResponseDto>.SuccessAsync(response, "Token refreshed successfully", true);

        }

    }
}
