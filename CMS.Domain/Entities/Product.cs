using CMS.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public double Price {  get; set; }
        public int Count { get; set; }
        public string ImageUrl { get; set; }
        public string ArCategory { get; set; }
        public string EnCategory { get; set; }


    }
}
