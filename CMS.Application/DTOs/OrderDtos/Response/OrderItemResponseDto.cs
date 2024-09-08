using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.OrderDtos.Response
{
    public class OrderItemResponseDto
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int HostingPackageId {  get; set; }
        public HostingPackageResponseDto? HostingPackage { get; set; }
        public int ProductId { get; set; }
        public ProductResponseDto? Product { get; set; }
        public int Count { get; set; }
        public string HostingPackageName { get; set; }
        public double HostingPackagePrice {  get; set; }
        public string ProductName { get; set; }
        public double? ProductPrice { get; set; }
    }
}
