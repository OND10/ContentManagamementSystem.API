using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDapperContext _context;
        public OrderRepository(ApplicationDapperContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateAsync(Order entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                const string sql = @"
                    INSERT INTO [Order] (UserId, Discount, OrderTotal, EnglishName, ArabicName, Email, PhoneNumber, OrderTime, Status, PaymentIntentId, StripeSessionId, CreatedAt, LastModifiedAt, ModifiedBy, IsDeleted, DeletedBy, DeletedAt)
                    VALUES (@UserId, @Discount, @OrderTotal, @EnglishName, @ArabicName, @Email, @PhoneNumber, @OrderTime, @Status, @PaymentIntentId, @StripeSessionId, @CreatedAt, @LastModifiedAt, @ModifiedBy, @IsDeleted, @DeletedBy, @DeletedAt);
                    SELECT CAST(SCOPE_IDENTITY() as int);"
                ;

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        var orderId = await db.ExecuteScalarAsync<int>(sql, entity, transaction: transaction);

                        foreach (var item in entity.OrderItems)
                        {
                            item.OrderId = orderId;
                            const string itemSql = @"
                                INSERT INTO OrderItems (OrderId, ProductId, HostingPackageId, Count, ProductName, ProductPrice, HostingPackageName, HostingPackagePrice)
                                VALUES (@OrderId, @ProductId, @HostingPackageId, @Count, @ProductName, @ProductPrice, @HostingPackageName, @HostingPackagePrice);"
                                ;

                            await db.ExecuteAsync(itemSql, item, transaction: transaction);
                        }

                        transaction.Commit();

                        entity.Id = orderId;
                        return entity;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Task<Order> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> FindAllAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindAsync(Expression<Func<Order, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Order, R>> selector, Expression<Func<Order, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllAsync<R>(Expression<Func<Order, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = $"SELECT * FROM Order WHERE Id = {id}";
                var result = await db.QueryFirstOrDefaultAsync<Order>(query, cancellationToken);

                if (result is not null)
                {
                    return result;

                }

                return null;
            }
        }

        public Task<IEnumerable<Order>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateAsync(Order entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
