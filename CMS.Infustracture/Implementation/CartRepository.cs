using CMS.Domain.Common.Exceptions;
using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using OnMapper;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace CMS.Infustracture.Implementation
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDapperContext _context;
        private readonly OnMapping _mapper;
        public CartRepository(ApplicationDapperContext context, OnMapping mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartItem> AddCartItemAsync(CartItem cartItem, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "INSERT INTO CartItem (CartId, HostingPackageId, ProductId, Count) VALUES (@CartId, @HostingPackageId, @ProductId, @Count); SELECT CAST(SCOPE_IDENTITY() as int)";
                cartItem.Id = await db.QuerySingleAsync<int>(query, cartItem);

                return cartItem;
            }
        }

        public async Task<Cart> CreateAsync(Cart entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "INSERT INTO Cart (UserId, Discount, CartTotal, ArabicFullName, EnglishFullName, PhoneNumber, Email) VALUES (@UserId, @Discount, @CartTotal, @ArabicFullName, @EnglishFullName, @PhoneNumber, @Email); SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = await db.QuerySingleAsync<int>(query, entity);
                entity.Id = id;
                return entity;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "DELETE FROM CartHeader WHERE Id = @Id";
                var result = await db.ExecuteAsync(query, new { Id = id });
                return true;
            }
        }

        public async Task<int> GetCartItemCountByCartHeaderIdAsync(int cartHeaderId, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT COUNT(*) FROM CartItem WHERE CartHeaderId = @CartHeaderId";
                return await db.ExecuteScalarAsync<int>(query, new { CartHeaderId = cartHeaderId });

            }
        }

        public async Task<bool> DeleteCartItemAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {

                var query = "DELETE FROM CartItem WHERE Id = @Id";
                var result = await db.ExecuteAsync(query, new { Id = id });
                return true;
            }
        }

     
        public Task<Cart> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM Cart WHERE UserId = @UserId";
                var result = await db.QueryFirstOrDefaultAsync<Cart>(query, new { UserId = userId });

                if (result != null)
                {
                    return result;
                }

                return await Task.FromResult<Cart>(null).WaitAsync(cancellationToken);
            }
        }

        public async Task<CartItem> GetCartItemAsync(int cartId, int hostingPackagetId, int productId, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM CartItem WHERE CartId = @CartId AND HostingPackageId = @HostingPackageId AND ProductId = @ProductId";
                var result = await db.QueryFirstOrDefaultAsync<CartItem>(query, new { CartId = cartId, HostingPackageId = hostingPackagetId, ProductId = productId });

                return result;
            }
        }

        public async Task<CartItem> GetCartItemByCartIdAsync(int cartId, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM CartItem WHERE Id = @Id";
                return await db.QuerySingleOrDefaultAsync<CartItem>(query, new { Id = cartId });
            }
        }

        public async Task<IQueryable<CartItem>> GetCartItemByIdAsync(int cartId, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM CartItem WHERE CartId = @CartId ";
                var result = db.Query<CartItem>(query, new { CartId = cartId }).AsQueryable();

                return await Task.FromResult<IQueryable<CartItem>>(result);
            }
        }

        public Task<Cart> UpdateAsync(Cart entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> UpdateCartItemAsync(CartItem cartItem, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "UPDATE CartItem SET Count = @Count WHERE Id = @Id";
                await db.ExecuteAsync(query, cartItem);
            }
            return cartItem;
        }

        
    }
}
