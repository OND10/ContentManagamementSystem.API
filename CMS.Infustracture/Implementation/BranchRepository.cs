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
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDapperContext _context;
        public BranchRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<Branch> CreateAsync(Branch entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@Location", entity.Location);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Fax", entity.Fax);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                
                await db.ExecuteAsync("Branch_Proc", parameters, commandType: CommandType.StoredProcedure);

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

                await db.ExecuteAsync("Branch_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        
        public async Task<IEnumerable<Branch>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<Branch>($"SELECT * FROM Branch");
                return result;
            }
        }

        public async Task<Branch> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<Branch>($"SELECT * FROM Branch WHERE Id = {id}");
                return result;
            }
        }


        public async Task<Branch> UpdateAsync(Branch entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@Location", entity.Location);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Fax", entity.Fax);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@ImageUrl", entity.ImageUrl);



                await db.ExecuteAsync("Branch_Proc", parameters, commandType: CommandType.StoredProcedure);

            }
            return entity;
        }

    }
}
