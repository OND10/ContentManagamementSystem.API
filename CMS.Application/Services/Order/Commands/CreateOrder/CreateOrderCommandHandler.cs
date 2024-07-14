using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.OrderDtos.Response;
using CMS.Domain.Common.Enums;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderResponseDto>
    {
        private readonly IOrderRepository _repository;
        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }


        public async Task<Result<OrderResponseDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedOrderResponse = new OrderResponseDto
                {
                    UserId = request.cartDto.CartResponse.UserId,
                    Discount = request.cartDto.CartResponse.Discount,
                    OrderTotal = request.cartDto.CartResponse.CartTotal,
                    EnglishName = request.cartDto.CartResponse.EnglishFullName,
                    ArabicName = request.cartDto.CartResponse.ArabicFullName,
                    Email = request.cartDto.CartResponse.Email,
                    PhoneNumber = request.cartDto.CartResponse.PhoneNumber,
                    OrderTime = DateTime.Now,
                    Status = StatusEnum.Pending.ToString(),
                    OrderDetails = new List<OrderItemResponseDto>()
                };

                var orderItems = request.cartDto.CartItemResponse.Select(cartDetail => new OrderItems
                {
                    ProductId = cartDetail.ProductId,
                    HostingPackageId = cartDetail.HostingPackageId,
                    Count = cartDetail.Count,
                    ProductName = cartDetail.Product.EnglishName,
                    ProductPrice = cartDetail.Product.Price,
                    HostingPackageName = cartDetail.HostingPackage.EnglishName,
                }).ToList();

                var order = new CMS.Domain.Entities.Order
                {
                    UserId = mappedOrderResponse.UserId,
                    Discount = mappedOrderResponse.Discount,
                    OrderTotal = mappedOrderResponse.OrderTotal,
                    EnglishName = mappedOrderResponse.EnglishName,
                    ArabicName = mappedOrderResponse.ArabicName,
                    Email = mappedOrderResponse.Email,
                    PhoneNumber = mappedOrderResponse.PhoneNumber,
                    Status = mappedOrderResponse.Status,
                    OrderTime = mappedOrderResponse.OrderTime,
                    OrderItems = orderItems
                };

                var createdOrder = await _repository.CreateAsync(order, cancellationToken);

                mappedOrderResponse.Id = createdOrder.Id;
                mappedOrderResponse.OrderDetails = createdOrder.OrderItems.Select(oi => new OrderItemResponseDto
                {
                    Id = oi.Id,
                    OrderHeaderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    HostingPackageId = oi.HostingPackageId,
                    Count = oi.Count,
                    ProductName = oi.ProductName,
                    ProductPrice = oi.ProductPrice,
                    HostingPackageName = oi.HostingPackageName,
                }).ToList();

                return await Result<OrderResponseDto>.SuccessAsync(mappedOrderResponse, ResponseStatus.CreateSuccess, true);
            }
            catch (Exception ex)
            {
                return await Result<OrderResponseDto>.FaildAsync(false, $"{ex.Message}");
            }
        }
    }

}
