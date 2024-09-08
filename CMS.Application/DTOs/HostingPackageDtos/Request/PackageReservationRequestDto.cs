using CMS.Application.Services.HostingPackage.Commands.HostingPackageReservation;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.HostingPackageDtos.Request
{
    public class PackageReservationRequestDto
    {
        public string UserEmail { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string StreetNo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public string PackageCategory { get; set; }
        public float MonthlyPrice { get; set; }
        public float YearlyPrice { get; set; }
        public string CpuCapacity { get; set; }
        public string HardCapacity { get; set; }
        public string TypeofHard { get; set; }


        public PackageReservationCommand ToCommand(PackageReservationRequestDto request)
        {
            return new PackageReservationCommand
            {
                UserEmail = request.UserEmail,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                CompanyName = request.CompanyName,
                StreetNo = request.StreetNo,
                City = request.City,
                Country = request.Country,
                PackageName = request.PackageName,
                PackageDescription = request.PackageDescription,
                PackageCategory = request.PackageCategory,
                CpuCapacity = request.CpuCapacity,
                HardCapacity = request.HardCapacity,
                TypeofHard = request.TypeofHard,
                MonthlyPrice = request.MonthlyPrice,
                YearlyPrice = request.YearlyPrice,

            };


        }


    }
}
