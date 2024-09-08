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
    public class AboutRepository : IAboutRepository
    {
        private readonly ApplicationDapperContext _context;
        public AboutRepository(ApplicationDapperContext context)
        {
            _context = context;
        }
        public async Task<About> CreateAsync(About entity, CancellationToken cancellationToken)
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
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CustomersCount", entity.CustomersCount);
                parameters.Add("@CitiesCount", entity.CitiesCount);
                parameters.Add("@EnMotivationletter", entity.EnMotivationletter);
                parameters.Add("@ArMotivationletter", entity.ArMotivationletter);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("About_Proc", parameters, commandType: CommandType.StoredProcedure);

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

                await db.ExecuteAsync("About_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }
      
        public async Task<IEnumerable<About>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<About>($"SELECT * FROM About");
                return result;
            }
        }

        public async Task<About> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<About>($"SELECT * FROM About WHERE Id = {id}");
                return result;
            }
        }

        public async Task<About> UpdateAsync(About entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var getAbout = await db.QueryFirstAsync<About>($"SELECT CreatedAt FROM About WHERE Id = {entity.Id}");
                entity.CreatedAt = getAbout.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishTitle", entity.EnglishTitle);
                parameters.Add("@ArabicTitle", entity.ArabicTitle);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CustomersCount", entity.CustomersCount);
                parameters.Add("@CitiesCount", entity.CitiesCount);
                parameters.Add("@EnMotivationletter", entity.EnMotivationletter);
                parameters.Add("@ArMotivationletter", entity.ArMotivationletter);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("About_Proc", parameters, commandType: CommandType.StoredProcedure);

            }
            return entity;
        }

    }
}
