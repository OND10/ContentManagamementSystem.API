using CMS.Application.Common.Handling;
using CMS.Application.Shared.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.UserDtos.Request
{
    public class LoginRequestDto : IEmailValidation, IPasswordValidation
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public async Task<Result<string>> Emailvalidate()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return await Result<string>.FaildAsync(false, "Please Enter a UserName");
            }
            
            return null;
        }

        public async Task<Result<string>> Passwordvalidate()
        {
            if (Password.Length is <= 6)
            {
                return await Result<string>.FaildAsync(false, "Password must be more than 6 characters");
            }

            return null;
        }
    }
}
