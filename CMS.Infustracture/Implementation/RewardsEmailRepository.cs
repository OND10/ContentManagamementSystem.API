using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System.Data;

namespace CMS.Infustracture.Implementation
{
    public class RewardsEmailRepository : IRewardsEmailRepository
    {
        private readonly ApplicationDapperContext _context;
        public RewardsEmailRepository(ApplicationDapperContext context) 
        {
            _context = context;
        }

        public async Task<RewardsEmail> CreateAsync(RewardsEmail entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var insertQuery = "Insert Into RewardsEmail (Email, Token, CreatedAt, ExpiredAt) Values (@Email, @Token, @CreatedAt, @ExpiredAt)";
                await db.ExecuteAsync(insertQuery, entity);

                //var selectQuery = "SELECT CAST(SCOPE_IDENTITY() as int)";
                //entity.Id = await db.QuerySingleAsync<int>(selectQuery);

                return entity;
            }
        }




        public async Task<IEnumerable<RewardsEmail>> GetAllAsync(CancellationToken cancellationToken)
        {
            using(IDbConnection db = _context.CreateConnection())
            {
                string query = $"Select * from RewardsEmail";

                var result = await db.QueryAsync<RewardsEmail>(query);

                return result;
            }
        }

        public async Task<RewardsEmail> GetByTokenAsync(string token, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                string query = $"SELECT * FROM RewardsEmail WHERE Token = '{token}'";

                var result = await db.QueryFirstOrDefaultAsync<RewardsEmail>(query);

                return result;
            }
        }
    }
}
