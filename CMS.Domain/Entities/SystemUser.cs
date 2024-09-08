﻿using Microsoft.AspNetCore.Identity;

namespace CMS.Domain.Entities
{
    public class SystemUser : IdentityUser
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
