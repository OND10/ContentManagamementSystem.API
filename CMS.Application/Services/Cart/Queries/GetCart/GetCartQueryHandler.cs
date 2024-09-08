using CMS.Application.Abstractions.Messaging;
using CMS.Application.Common.Handling;
using CMS.Application.DTOs.HostingPackageDtos.Response;
using CMS.Application.DTOs.ShoppingCartDtos.Request;
using CMS.Application.DTOs.ShoppingCartDtos.Response;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Domain.Shared;
using OnMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Services.Cart.Queries.GetCart
{
    public class GetCartQueryHandler : IQueryHandler<GetCartQuery, IEnumerable<CartDto>>
    {
        private readonly ICartRepository _repository;
        private readonly IHostingPackageRepository _packageRepository;
        private readonly OnMapping _mapper;

        public GetCartQueryHandler(ICartRepository repository, IHostingPackageRepository packageRepository, OnMapping mapper)
        {
            _repository = repository;
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CartDto>>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var cartHeader = await _repository.GetCartByUserIdAsync(request.userId, cancellationToken);

            if (cartHeader == null)
            {
                return await Result<IEnumerable<CartDto>>.FaildAsync(false, ResponseStatus.Faild);
            }

            var mappedCartHeader = new CartResponseDto
            {
                Id = cartHeader.Id,
                UserId = cartHeader.UserId,
                Discount = cartHeader.Discount,
                ArabicFullName = cartHeader.ArabicFullName,
                CartTotal = cartHeader.CartTotal,
                Email = cartHeader.Email,
                EnglishFullName = cartHeader.EnglishFullName,
                PhoneNumber = cartHeader.PhoneNumber,
            };

            var cart = new List<CartDto>
        {
            new CartDto
            {
                CartResponse = mappedCartHeader,
            }
        };

            var cartDetailsByCartId = await _repository.GetCartItemByIdAsync(cart.First().CartResponse.Id, cancellationToken);
            var mappedCartItemResponse = await _mapper.MapCollection<CartItem, CartItemResponseDto>(cartDetailsByCartId);
            cart.First().CartItemResponse = mappedCartItemResponse.Data;

            var packageList = await _packageRepository.GetAllAsync(cancellationToken);
            var packageResponseList = await _mapper.MapCollection<HostingPackages, HostingPackageResponseDto>(packageList);

            var mappedCartModel = await _mapper.Map<CartResponseDto, CMS.Domain.Entities.Cart>(cart.First().CartResponse);
            var cartHeaderModel = mappedCartModel.Data;

            foreach (var item in cart.First().CartItemResponse)
            {
                item.HostingPackage = packageResponseList.Data.FirstOrDefault(u => u.Id == item.HostingPackageId);
                item.CartHeader = cartHeaderModel; // Ensure all items get the cart header
                cart.First().CartResponse.CartTotal += (item.Count * item.HostingPackage.BeginPriceMonthly);
            }

            if (cart.First().CartResponse.Discount != null)
            {
                if (cart.First().CartResponse.CartTotal > cart.First().CartResponse.Discount)
                {
                    cart.First().CartResponse.CartTotal -= cart.First().CartResponse.Discount;
                }
                else
                {
                    return await Result<IEnumerable<CartDto>>.SuccessAsync(cart, ResponseStatus.GetSuccess, true);
                }
            }

            return await Result<IEnumerable<CartDto>>.SuccessAsync(cart, ResponseStatus.Success, true);
        }
    }

}
