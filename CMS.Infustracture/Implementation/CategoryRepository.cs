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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDapperContext _context;
        public CategoryRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateAsync(Category entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Category_Proc", parameters, commandType: CommandType.StoredProcedure);
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

                await db.ExecuteAsync("Category_Proc", parameters, commandType: CommandType.StoredProcedure);
            }
            return true;
        }

        public Task<IEnumerable<Category>> FindAllAsync(Expression<Func<Category, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindAsync(Expression<Func<Category, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Category, R>> selector, Expression<Func<Category, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync<R>(Expression<Func<Category, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            using(IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM Category";
                var result = await db.QueryAsync<Category>(query, cancellationToken);

                if(result.Count() > 0)
                {
                    return result;
                }

                return null;
            }
        }

        public async Task<Category> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = $"SELECT * FROM Category WHERE Id = {id}";

                var result = await db.QueryFirstOrDefaultAsync<Category>(query, cancellationToken);

                if (result is not null)
                {
                    return result;
                }
                return null;
            }
        }

        public Task<IEnumerable<Category>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> UpdateAsync(Category entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {

                var getHome = await db.QueryFirstAsync<Category>($"SELECT CreatedAt FROM Category WHERE Id = {entity.Id}");
                entity.CreatedAt = getHome.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Category_Proc", parameters, commandType: CommandType.StoredProcedure);
            }
            return entity;
        }
    }
}
