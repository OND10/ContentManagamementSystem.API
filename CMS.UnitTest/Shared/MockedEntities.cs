using Bogus;
using CMS.Application.DTOs.ProductDtos.Request;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.Services.Product.Queries.GetProduct;
using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.UnitTest.Shared
{
    public class MockedEntities
    {
        public Product product = new Faker<Product>()
          .RuleFor(p => p.Id, f => f.Random.Int())
          .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
          .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
          .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
          .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
          .RuleFor(p => p.Count, f => f.Random.Int())
          .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
          .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
          .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
          .RuleFor(p => p.Price, f => f.Random.Double());


        public List<Product> productList = new List<Product>
        {
            new Faker<Product>()
              .RuleFor(p => p.Id, f => f.Random.Int())
              .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
              .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
              .RuleFor(p => p.Count, f => f.Random.Int())
              .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
              .RuleFor(p => p.Price, f => f.Random.Double()),

            new Faker<Product>()
              .RuleFor(p => p.Id, f => f.Random.Int())
              .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
              .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
              .RuleFor(p => p.Count, f => f.Random.Int())
              .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
              .RuleFor(p => p.Price, f => f.Random.Double())
        };



        public ProductRequestDto productRequestDto = new Faker<ProductRequestDto>()
              .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
              .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
              .RuleFor(p => p.Count, f => f.Random.Int())
              .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
              .RuleFor(p => p.Price, f => f.Random.Double());


        public ProductResponseDto productResponseDto = new Faker<ProductResponseDto>()
              .RuleFor(p => p.Id, f => f.Random.Int())
              .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
              .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
              .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
              .RuleFor(p => p.Count, f => f.Random.Int())
              .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
              .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
              .RuleFor(p => p.Price, f => f.Random.Double());


        public List<ProductResponseDto> productResponseDtoList = new List<ProductResponseDto>
        {
            new Faker<ProductResponseDto>()
                  .RuleFor(p => p.Id, f => f.Random.Int())
                  .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                  .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.Count, f => f.Random.Int())
                  .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
                  .RuleFor(p => p.Price, f => f.Random.Double()),

            new Faker<ProductResponseDto>()
                  .RuleFor(p => p.Id, f => f.Random.Int())
                  .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                  .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.Count, f => f.Random.Int())
                  .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
                  .RuleFor(p => p.Price, f => f.Random.Double())
        };

        public GetProductQuery productquery = new GetProductQuery()
        {

        };
    }
}

