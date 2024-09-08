using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.HostingPackageDtos.Response
{
    public class PackageReservationResponseDto
    {
        public int Id { get; set; }
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


        public PackageReservationResponseDto FromModel(PackageReservation model)
        {
            return new PackageReservationResponseDto
            {
                Id = model.Id,
                City = model.City,
                Country = model.Country,
                PackageName = model.PackageName,
                PackageDescription = model.PackageDescription,
                PackageCategory = model.PackageCategory,
                CompanyName = model.CompanyName,
                CpuCapacity = model.CpuCapacity,
                HardCapacity = model.HardCapacity,
                TypeofHard = model.TypeofHard,
                FullName = model.FullName,
                MonthlyPrice = model.MonthlyPrice,
                YearlyPrice = model.YearlyPrice,
                PhoneNumber = model.PhoneNumber,
                StreetNo = model.StreetNo,
                UserEmail = model.UserEmail,
            };
        }
    }
}
