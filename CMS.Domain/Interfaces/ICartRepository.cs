using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Interfaces
{
    public interface ICartRepository
    {

        Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken);
        Task<Cart> UpdateAsync(Cart entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
        Task<bool> DeleteCartItemAsync(int id, CancellationToken cancellationToken);
        Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Cart> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken);
        Task <CartItem> AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken);
        Task<CartItem> GetCartItemAsync(int cartId, int hostingPackagetId, int productId, CancellationToken cancellationToken);
        Task<CartItem> GetCartItemByCartIdAsync(int cartId, CancellationToken cancellationToken);
        Task <CartItem> UpdateCartItemAsync(CartItem cartItem, CancellationToken cancellationToken);
        Task<IQueryable<CartItem>> GetCartItemByIdAsync(int cartId, CancellationToken cancellationToken);
        Task<int> GetCartItemCountByCartHeaderIdAsync(int cartHeaderId, CancellationToken cancellationToken);

    }
}
