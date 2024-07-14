using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.HostingPackageDtos.Request;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.Services.HostingPackage.Commands.CreateHostingPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.HostingPackage.Commands.UpdateHostingPackage
{
    public class UpdateHostingPackageCommand : ICommand<HostingPackageResponseDto>
    {
        public int Id {  get; set; }
        public string EnglishName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicName { get; set; }
        public string ArabicDescription { get; set; }
        public int NumberofHostingPackage { get; set; }
        public string EnCategory { get; set; }
        public string ArCategory { get; set; }
        public double BeginPriceMonthly { get; set; }
        public double BeginPriceYearly { get; set; }
        public double DiscountPriceMonthly { get; set; }
        public double DiscountPriceYearly { get; set; }
        public string CpuCapacity { get; set; }
        public string RamCapacity { get; set; }
        public string HardDriveCapacity { get; set; }
        public string TypeofHard { get; set; }
        public string ImageUrl { get; set; }
        public string ModifiedBy { get; set; }


        public async Task<UpdateHostingPackageCommand> FromRequest(HostingPackageRequestDto request)
        {
            return await Task.FromResult<UpdateHostingPackageCommand>(new UpdateHostingPackageCommand
            {
                EnglishName = request.EnglishName,
                EnglishDescription = request.EnglishDescription,
                ArabicName = request.ArabicName,
                ArabicDescription = request.ArabicDescription,
                NumberofHostingPackage = request.NumberofHostingPackage,
                EnCategory = request.EnCategory,
                ArCategory = request.ArCategory,
                BeginPriceMonthly = request.BeginPriceMonthly,
                BeginPriceYearly = request.BeginPriceYearly,
                DiscountPriceMonthly = request.DiscountPriceMonthly,
                DiscountPriceYearly = request.DiscountPriceYearly,
                CpuCapacity = request.CpuCapacity,
                RamCapacity = request.RamCapacity,
                HardDriveCapacity = request.HardDriveCapacity,
                TypeofHard = request.TypeofHard,
                ImageUrl = request.ImageUrl
            });
        }
    }
}
