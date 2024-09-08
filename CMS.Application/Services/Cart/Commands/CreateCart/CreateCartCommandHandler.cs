using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.DTOs.ShoppingCartDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;

namespace CMS.Application.Services.Cart.Commands.CreateCart
{
    public class CreateCartCommandHandler : ICommandHandler<CreateCartCommand, CartDto>
    {
        private readonly ICartRepository _repository;
        private readonly OnMapping _mapper;
        public CreateCartCommandHandler(ICartRepository repository, OnMapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<CartDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cartHeader = await _repository.GetCartByUserIdAsync(request.CartResponse.UserId, cancellationToken);
                if (cartHeader == null)
                {
                    // Create cartHeader
                    var cartmodel = await _mapper.Map<CartResponseDto, CMS.Domain.Entities.Cart>(request.CartResponse);
                    await _repository.CreateAsync(cartmodel.Data, cancellationToken);

                    foreach (var item in request.CartItemResponse)
                    {
                        var cartItem = await _mapper.Map<CartItemResponseDto, CartItem>(item);
                        cartItem.Data.CartId = cartmodel.Data.Id;
                        await _repository.AddCartItemAsync(cartItem.Data, cancellationToken);
                    }
                    var mappedCart = new CartDto
                    {
                        CartResponse = new CartResponseDto
                        {
                            Id = cartmodel.Data.Id,
                            UserId = cartmodel.Data.UserId,
                            Discount = cartmodel.Data.Discount,
                            CartTotal = cartmodel.Data.CartTotal,
                            ArabicFullName = cartmodel.Data.ArabicFullName,
                            EnglishFullName = cartmodel.Data.EnglishFullName,
                            PhoneNumber = cartmodel.Data.PhoneNumber,
                            Email = cartmodel.Data.Email
                        },
                        CartItemResponse = request.CartItemResponse.Select(item => new CartItemResponseDto
                        {
                            CartId = cartmodel.Data.Id,
                            HostingPackageId = item.HostingPackageId,
                            ProductId = item.ProductId,
                            Count = item.Count,
                        }).ToList()
                    };
                    return await Result<CartDto>.SuccessAsync(mappedCart, "Added Successfully", true);
                }
                else
                {
                    // Cart exists, check if item have the same product //Update
                    foreach (var item in request.CartItemResponse)
                    {
                        var cartItem = await _repository.GetCartItemAsync(cartHeader.Id, item.HostingPackageId, item.ProductId, cancellationToken);
                        if (cartItem == null)
                        {
                            var newItem = new CartItem
                            {
                                CartId = cartHeader.Id,
                                HostingPackageId = item.HostingPackageId,
                                ProductId = item.ProductId,
                                Count = item.Count
                            };
                            //newItem.CartId = cartHeader.Id;
                            await _repository.AddCartItemAsync(newItem, cancellationToken);
                        }
                        else
                        {
                            cartItem.Count += item.Count;
                            await _repository.UpdateCartItemAsync(cartItem, cancellationToken);
                        }
                    }

                    //returning the updated cart 
                    var updatedCart = new CartDto
                    {
                        CartResponse = new CartResponseDto
                        {
                            Id = cartHeader.Id,
                            UserId = cartHeader.UserId,
                            Discount = cartHeader.Discount,
                            CartTotal = cartHeader.CartTotal,
                            ArabicFullName = cartHeader.ArabicFullName,
                            EnglishFullName = cartHeader.EnglishFullName,
                            PhoneNumber = cartHeader.PhoneNumber,
                            Email = cartHeader.Email
                        },
                        CartItemResponse = request.CartItemResponse.Select(item => new CartItemResponseDto
                        {
                            CartId = cartHeader.Id,
                            HostingPackageId = item.HostingPackageId,
                            ProductId = item.ProductId,
                            Count = item.Count
                        }).ToList()
                    };
                    return await Result<CartDto>.SuccessAsync(updatedCart, "Added Successfully", true);
                }
            }
            catch
            {
                return await Result<CartDto>.FaildAsync(false, ResponseStatus.Faild);
            }
        }
    }
}
