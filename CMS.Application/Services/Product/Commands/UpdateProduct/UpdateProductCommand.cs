using CMS.Application.Abstractions.Messaging;
using CMS.Application.DTOs.ProductDtos.Request;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Product.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : ICommand<ProductResponseDto>
    {
        public int Id {  get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string ImageUrl { get; set; }
        public string ArCategory { get; set; }
        public string EnCategory { get; set; }
        public string ModifiedBy {  get; set; }

        public async Task<UpdateProductCommand> FromRequest(ProductRequestDto request)
        {
            return await Task.FromResult<UpdateProductCommand>(new UpdateProductCommand
            {
                EnglishName = request.EnglishName,
                EnglishDescription = request.EnglishDescription,
                ArabicName = request.ArabicName,
                ArabicDescription = request.ArabicDescription,
                EnCategory = request.EnCategory,
                ArCategory = request.ArCategory,
                ImageUrl = request.ImageUrl,
                Count = request.Count,
                Price = request.Price,
            });
        }
    }
}
