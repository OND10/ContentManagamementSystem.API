using CMS.Application.Services.Image.Interface;
using CMS.Application.Services.User.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitTest.Shared
{
    public interface IUnitofTestService
    {
        IUserService userService { get; }
        IImageService imageService { get; }
    }
}
