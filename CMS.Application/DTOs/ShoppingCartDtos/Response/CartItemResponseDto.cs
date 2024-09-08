using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.DTOs.ShoppingCartDtos.Response
{
    public class CartItemResponseDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart? CartHeader { get; set; }
        public int HostingPackageId { get; set; }
        public HostingPackageResponseDto? HostingPackage { get; set; }
        public int ProductId { get; set; }
        public ProductResponseDto? Product { get; set; }
        public int Count { get; set; }
    }
}
