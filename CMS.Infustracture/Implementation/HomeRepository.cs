using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDapperContext _context;
        public HomeRepository(ApplicationDapperContext context) 
        {
            _context = context;
        }
        public async Task<Home> CreateAsync(Home entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishTitle", entity.EnglishTitle);
                parameters.Add("@ArabicTitle", entity.ArabicTitle);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@LogoUrl", entity.LogoUrl);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Home_Proc", parameters, commandType: CommandType.StoredProcedure);

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

                await db.ExecuteAsync("Home_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public Task<IEnumerable<Home>> FindAllAsync(Expression<Func<Home, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Home> FindAsync(Expression<Func<Home, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Home, R>> selector, Expression<Func<Home, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Home>> GetAllAsync<R>(Expression<Func<Home, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Home>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<Home>($"SELECT * FROM Home");
                return result;
            }
        }

        public async Task<Home> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                if(id is 0)
                {
                    return await Task.FromResult<Home>(null);
                }
                var result = await db.QueryFirstOrDefaultAsync<Home>($"SELECT * FROM Home WHERE Id = {id}");
                if(result is null)
                {
                    return await Task.FromResult<Home>(null);
                }
                return result;
            }
        }

        public Task<IEnumerable<Home>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Home> UpdateAsync(Home entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var getHome = await db.QueryFirstAsync<Home>($"SELECT CreatedAt FROM Home WHERE Id = {entity.Id}");
                entity.CreatedAt = getHome.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishTitle", entity.EnglishTitle);
                parameters.Add("@ArabicTitle", entity.ArabicTitle);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@LogoUrl", entity.LogoUrl);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Home_Proc", parameters, commandType: CommandType.StoredProcedure);

            }
            return entity;
        }

    }
}
