using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CMS.Application.Services.HostingPackage.Commands.HostingPackageReservation
{
    public class PackageReservationCommand : ICommand<PackageReservationResponseDto>
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

        public PackageReservation ToModel(PackageReservationCommand command)
        {
            return new PackageReservation
            {
                UserEmail = command.UserEmail,
                FullName = command.FullName,
                PhoneNumber = command.PhoneNumber,
                CompanyName = command.CompanyName,
                StreetNo = command.StreetNo,
                City = command.City,
                Country = command.Country,
                PackageName = command.PackageName,
                PackageDescription = command.PackageDescription,
                PackageCategory = command.PackageCategory,
                CpuCapacity = command.CpuCapacity,
                HardCapacity = command.HardCapacity,
                TypeofHard = command.TypeofHard,
                MonthlyPrice = command.MonthlyPrice,
                YearlyPrice = command.YearlyPrice,

            };


        }
    }
}
