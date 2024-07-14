using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDapperContext _context;
        public ProductRepository(ApplicationDapperContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product entity, CancellationToken cancellationToken)
        {
            using(IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@Price", entity.Price);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@ArCategory", entity.ArCategory);
                parameters.Add("@EnCategory", entity.EnCategory);
                parameters.Add("@Count", entity.Count);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Product_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "DELETE");
                parameters.Add("@Id", id);

                await db.ExecuteAsync("Product_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public Task<IEnumerable<Product>> FindAllAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Product> FindAsync(Expression<Func<Product, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Product, R>> selector, Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync<R>(Expression<Func<Product, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<Product>($"SELECT * FROM Product");
                return result;
            }
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<Product>($"SELECT * FROM Product WHERE Id = {id}");
                return result;
            }
        }

        public Task<IEnumerable<Product>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateAsync(Product entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {

                var getProduct = await db.QueryFirstAsync<Product>($"SELECT CreatedAt FROM Product WHERE Id = {entity.Id}");
                entity.CreatedAt = getProduct.CreatedAt;
                
                if(entity.ImageUrl is null)
                {
                    entity.ImageUrl = getProduct.ImageUrl;
                }

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@Price", entity.Price);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@ArCategory", entity.ArCategory);
                parameters.Add("@EnCategory", entity.EnCategory);
                parameters.Add("@Count", entity.Count);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);

                await db.ExecuteAsync("Product_Proc", parameters, commandType: CommandType.StoredProcedure);
            }
            return entity;
        }
    }
}
