using Bogus;
using CMS.Application.DTOs.EmployeeDtos.Request;
using CMS.Application.DTOs.EmployeeDtos.Response;
using CMS.Application.DTOs.HostingPackageDtos.Request;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.DTOs.ProductDtos.Request;
using CMS.Application.DTOs.ProductDtos.Response;
using CMS.Application.DTOs.ShoppingCartDtos.Response;
using CMS.Application.Services.Cart.Commands.CreateCart;
using CMS.Application.Services.Cart.Commands.DeleteCart;
using CMS.Application.Services.Cart.Queries.GetCart;
using CMS.Application.Services.Employee.Commands.CreateEmployee;
using CMS.Application.Services.Employee.Queries.GetEmployee;
using CMS.Application.Services.HostingPackage.Commands.CreateHostingPackage;
using CMS.Application.Services.HostingPackage.Commands.DeleteHostingPackage;
using CMS.Application.Services.HostingPackage.Commands.UpdateHostingPackage;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackage;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackageBasedonLang;
using CMS.Application.Services.HostingPackage.Queries.GetHostingPackageById;
using CMS.Application.Services.Product.Commands.CreateProduct;
using CMS.Application.Services.Product.Commands.DeleteProduct;
using CMS.Application.Services.Product.Commands.UpdateProduct;
using CMS.Application.Services.Product.Queries.GetProduct;
using CMS.Application.Services.Product.Queries.GetProductBasedonLang;
using CMS.Application.Services.Product.Queries.GetProductById;
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
        public GetProductByIdQuery GetProductByIdQuery = new GetProductByIdQuery()
        {
            Id = 1
        };
        public GetProductBasedonLangQuery GetProductBasedonLangQuery = new GetProductBasedonLangQuery()
        {
            lang = "ar"
        };
        public CreateProductCommand CreateProductCommand = new Faker<CreateProductCommand>()
                  .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                  .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                  .RuleFor(p => p.Count, f => f.Random.Int())
                  .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                  .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
                  .RuleFor(p => p.Price, f => f.Random.Double());

        public UpdateProductCommand UpdateProductCommand = new Faker<UpdateProductCommand>()
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


        public DeleteProductCommand DeleteProductCommand = new DeleteProductCommand()
        {
            Id = 1
        };


        // ----------------------------------------------------------------------
        // HostingPackage
        //-----------------------------------------------------------------------

        public HostingPackages hostingPackages = new Faker<HostingPackages>()
         .RuleFor(p => p.Id, f => f.Random.Int())
         .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
         .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
         .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
         .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
         .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
         .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
         .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
         .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
         .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
         .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
         .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
         .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
         .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
         .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
         .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
         .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());



        public List<HostingPackages> hostingPackagesList = new List<HostingPackages>
        {
            new Faker<HostingPackages>()
             .RuleFor(p => p.Id, f => f.Random.Int())
             .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
             .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
             .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
             .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
             .RuleFor(p => p.ImageUrl, f => f.Lorem.Word()),

            new Faker<HostingPackages>()
             .RuleFor(p => p.Id, f => f.Random.Int())
             .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
             .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
             .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
             .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
             .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
        };



        public HostingPackageRequestDto hostingPackageRequestDto = new Faker<HostingPackageRequestDto>()
             .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
             .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
             .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
             .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
             .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
             .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
             .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
             .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
             .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());


        public HostingPackageResponseDto hostingPackageResponseDto = new Faker<HostingPackageResponseDto>()
                .RuleFor(p => p.Id, f => f.Random.Int())
                .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
                .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
                .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
                .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
                .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
                .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
                .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());

        public List<HostingPackageResponseDto> HostingPackageResponseDtoList = new List<HostingPackageResponseDto>
        {
            new Faker<HostingPackageResponseDto>()
                    .RuleFor(p => p.Id, f => f.Random.Int())
                    .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                    .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                    .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                    .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                    .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                    .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                    .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
                    .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
                    .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
                    .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
                    .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
                    .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
                    .RuleFor(p => p.ImageUrl, f => f.Lorem.Word()),

            new Faker<HostingPackageResponseDto>()
                    .RuleFor(p => p.Id, f => f.Random.Int())
                    .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                    .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                    .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                    .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                    .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                    .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                    .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
                    .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
                    .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
                    .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
                    .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
                    .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
                    .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
                    .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
        };

        public GetHostingPackageQuery gethostingPackageQuery = new GetHostingPackageQuery
        {

        };

        public GetHostingPackageByIdQuery gethostingPackageQueryById = new GetHostingPackageByIdQuery
        {
            Id = 1
        };

        public GetHostingPackageBasedonLangQuery GetHostingPackageBasedonLangQuery = new GetHostingPackageBasedonLangQuery
        {
            lang = "ar"
        };

        public CreateHostingPackageCommand CreateHostingPackageCommand = new Faker<CreateHostingPackageCommand>()
                .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
                .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
                .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
                .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
                .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
                .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
                .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
                .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());

        public UpdateHostingPackageCommand UpdateHostingPackageCommand = new Faker<UpdateHostingPackageCommand>()
                        .RuleFor(p => p.EnglishName, f => f.Lorem.Word())
                        .RuleFor(p => p.ArabicName, f => f.Lorem.Word())
                        .RuleFor(p => p.ArCategory, f => f.Lorem.Word())
                        .RuleFor(p => p.EnCategory, f => f.Lorem.Word())
                        .RuleFor(p => p.EnglishDescription, f => f.Lorem.Word())
                        .RuleFor(p => p.ArabicDescription, f => f.Lorem.Word())
                        .RuleFor(p => p.BeginPriceMonthly, f => f.Random.Double())
                        .RuleFor(p => p.BeginPriceYearly, f => f.Random.Double())
                        .RuleFor(p => p.DiscountPriceMonthly, f => f.Random.Double())
                        .RuleFor(p => p.DiscountPriceYearly, f => f.Random.Double())
                        .RuleFor(p => p.NumberofHostingPackage, f => f.Random.Int())
                        .RuleFor(p => p.CpuCapacity, f => f.Lorem.Word())
                        .RuleFor(p => p.RamCapacity, f => f.Lorem.Word())
                        .RuleFor(p => p.HardDriveCapacity, f => f.Lorem.Word())
                        .RuleFor(p => p.TypeofHard, f => f.Lorem.Word())
                        .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());


        public DeleteHostingPackageCommand DeleteHostingPackageCommand = new DeleteHostingPackageCommand()
        {
            Id = 1
        };

        //--------------------------------------------------------------------------
        // Employee
        //--------------------------------------------------------------------------

        public Employee employee = new Faker<Employee>()
         .RuleFor(p => p.Id, f => f.Random.Int())
         .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
         .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
         .RuleFor(p => p.Location, f => f.Lorem.Word())
         .RuleFor(p => p.Email, f => f.Lorem.Word())
         .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
         .RuleFor(p => p.Department, f => f.Lorem.Word())
         .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());



        public List<Employee> employeeList = new List<Employee>
        {
            new Faker<Employee>()
              .RuleFor(p => p.Id, f => f.Random.Int())
             .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
             .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
             .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
             .RuleFor(p => p.Location, f => f.Lorem.Word())
             .RuleFor(p => p.Email, f => f.Lorem.Word())
             .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
             .RuleFor(p => p.Department, f => f.Lorem.Word())
             .RuleFor(p => p.ImageUrl, f => f.Lorem.Word()),

            new Faker<Employee>()
             .RuleFor(p => p.Id, f => f.Random.Int())
             .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
             .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
             .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
             .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
             .RuleFor(p => p.Location, f => f.Lorem.Word())
             .RuleFor(p => p.Email, f => f.Lorem.Word())
             .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
             .RuleFor(p => p.Department, f => f.Lorem.Word())
             .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
        };



        public EmployeeRequestDto employeeRequestDto = new Faker<EmployeeRequestDto>()
         .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
         .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
         .RuleFor(p => p.Location, f => f.Lorem.Word())
         .RuleFor(p => p.Email, f => f.Lorem.Word())
         .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
         .RuleFor(p => p.Department, f => f.Lorem.Word())
         .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());


        public EmployeeResponseDto employeeResponseDto = new Faker<EmployeeResponseDto>()
          .RuleFor(p => p.Id, f => f.Random.Int())
         .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
         .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
         .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
         .RuleFor(p => p.Location, f => f.Lorem.Word())
         .RuleFor(p => p.Email, f => f.Lorem.Word())
         .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
         .RuleFor(p => p.Department, f => f.Lorem.Word())
         .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());


        public List<EmployeeResponseDto> employeeResponseDtoList = new List<EmployeeResponseDto>
        {
            new Faker<EmployeeResponseDto>()
                 .RuleFor(p => p.Id, f => f.Random.Int())
                 .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                 .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                 .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
                 .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
                 .RuleFor(p => p.Location, f => f.Lorem.Word())
                 .RuleFor(p => p.Email, f => f.Lorem.Word())
                 .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
                 .RuleFor(p => p.Department, f => f.Lorem.Word())
                 .RuleFor(p => p.ImageUrl, f => f.Lorem.Word()),

           new Faker<EmployeeResponseDto>()
                 .RuleFor(p => p.Id, f => f.Random.Int())
                 .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                 .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                 .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
                 .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
                 .RuleFor(p => p.Location, f => f.Lorem.Word())
                 .RuleFor(p => p.Email, f => f.Lorem.Word())
                 .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
                .RuleFor(p => p.Department, f => f.Lorem.Word())
                .RuleFor(p => p.ImageUrl, f => f.Lorem.Word())
        };

        public GetEmployeeQuery employeetquery = new GetEmployeeQuery()
        {

        };

        public CreateEmployeeCommand CreatEemployeeCommand = new Faker<CreateEmployeeCommand>()
                     .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                     .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                     .RuleFor(p => p.ArPosition, f => f.Lorem.Word())
                     .RuleFor(p => p.EnPosition, f => f.Lorem.Word())
                     .RuleFor(p => p.Location, f => f.Lorem.Word())
                     .RuleFor(p => p.Email, f => f.Lorem.Word())
                     .RuleFor(p => p.PhoneNumber, f => f.Lorem.Word())
                     .RuleFor(p => p.Department, f => f.Lorem.Word())
                     .RuleFor(p => p.ImageUrl, f => f.Lorem.Word());

        //-----------------------------------------------------------------------
        // Cart
        //-----------------------------------------------------------------------

        public Cart cart = new Faker<Cart>()
          .RuleFor(p => p.Id, f => f.Random.Int())
          .RuleFor(p => p.UserId, f => f.Lorem.Word())
          .RuleFor(p => p.Discount, f => f.Random.Double())
          .RuleFor(p => p.CartTotal, f => f.Random.Double())
          .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
          .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
          .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
          .RuleFor(p => p.Email, f => f.Lorem.Word());


        public List<Cart> cartList = new List<Cart>
        {
            new Faker<Cart>()
              .RuleFor(p => p.Id, f => f.Random.Int())
          .RuleFor(p => p.UserId, f => f.Lorem.Word())
          .RuleFor(p => p.Discount, f => f.Random.Double())
          .RuleFor(p => p.CartTotal, f => f.Random.Double())
          .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
          .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
          .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
          .RuleFor(p => p.Email, f => f.Lorem.Word()),


            new Faker<Cart>()
              .RuleFor(p => p.Id, f => f.Random.Int())
          .RuleFor(p => p.UserId, f => f.Lorem.Word())
          .RuleFor(p => p.Discount, f => f.Random.Double())
          .RuleFor(p => p.CartTotal, f => f.Random.Double())
          .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
          .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
          .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
          .RuleFor(p => p.Email, f => f.Lorem.Word())

        };






        public CartResponseDto CartResponseDto = new Faker<CartResponseDto>()
                .RuleFor(p => p.Id, f => f.Random.Int())
                .RuleFor(p => p.UserId, f => f.Lorem.Word())
                .RuleFor(p => p.Discount, f => f.Random.Double())
                .RuleFor(p => p.CartTotal, f => f.Random.Double())
                .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
                .RuleFor(p => p.Email, f => f.Lorem.Word());



        public List<CartResponseDto> cartResponseDtoList = new List<CartResponseDto>
        {
            new Faker<CartResponseDto>()
                .RuleFor(p => p.Id, f => f.Random.Int())
                .RuleFor(p => p.UserId, f => f.Lorem.Word())
                .RuleFor(p => p.Discount, f => f.Random.Double())
                .RuleFor(p => p.CartTotal, f => f.Random.Double())
                .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
                .RuleFor(p => p.Email, f => f.Lorem.Word()),


            new Faker<CartResponseDto>()
                    .RuleFor(p => p.Id, f => f.Random.Int())
                    .RuleFor(p => p.UserId, f => f.Lorem.Word())
                    .RuleFor(p => p.Discount, f => f.Random.Double())
                    .RuleFor(p => p.CartTotal, f => f.Random.Double())
                    .RuleFor(p => p.EnglishFullName, f => f.Lorem.Word())
                    .RuleFor(p => p.ArabicFullName, f => f.Lorem.Word())
                    .RuleFor(p => p.PhoneNumber, f => f.Random.Word())
                    .RuleFor(p => p.Email, f => f.Lorem.Word())
        };

        public GetCartQuery cartquery = new GetCartQuery()
        {

        };

        public CreateCartCommand CreateCartCommand = new CreateCartCommand();
                    
        

        public DeleteCartCommand DeleteCartCommand = new DeleteCartCommand
        {
            Id = 1
        };

    };
}



