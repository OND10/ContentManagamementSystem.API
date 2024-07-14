using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class HostingPackages : AuditableEntity
    {
        public int Id {  get; set; }
        public string EnglishName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicName { get; set; }
        public string ArabicDescription { get; set; }
        public int NumberofHostingPackage { get; set; }
        public string EnCategory {  get; set; }
        public string ArCategory {  get; set; }
        public double BeginPriceMonthly { get; set; }
        public double BeginPriceYearly { get; set; }
        public double DiscountPriceMonthly { get; set; }
        public double DiscountPriceYearly { get; set; }
        public string CpuCapacity {  get; set; }
        public string RamCapacity {  get; set; }
        public string HardDriveCapacity { get; set; }
        public string TypeofHard {  get; set; }
        public string ImageUrl {  get; set; }
    }
}
