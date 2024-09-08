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
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDapperContext _context;
        public ContactRepository(ApplicationDapperContext context)
        {
            _context = context;
        }
        public async Task<Contact> CreateAsync(Contact entity, CancellationToken cancellationToken)
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
                parameters.Add("@Phone", entity.PhoneNumber);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@Address", entity.Address);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Contact_Proc", parameters, commandType: CommandType.StoredProcedure);

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

                await db.ExecuteAsync("Contact_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public Task<IEnumerable<Contact>> FindAllAsync(Expression<Func<Contact, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> FindAsync(Expression<Func<Contact, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Contact, R>> selector, Expression<Func<Contact, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync<R>(Expression<Func<Contact, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<Contact>($"SELECT * FROM Contact");
                return result;
            }
        }

        public async Task<Contact> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<Contact>($"SELECT * FROM Contact WHERE Id = {id}");
                return result;
            }
        }

        public async Task<int> GetVisitorsCount(CancellationToken cancellationToken)
        {
            using(IDbConnection db = _context.CreateConnection())
            {
                var sql = "SELECT COUNT(Id) FROM RewardsEmail";

                var result = await db.QueryFirstAsync<int>(sql, cancellationToken);

                return result;
            }
        }

        public Task<IEnumerable<Contact>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Contact> UpdateAsync(Contact entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var getContact = await db.QueryFirstAsync<Contact>($"SELECT CreatedAt FROM Contact WHERE Id = {entity.Id}");
                entity.CreatedAt = getContact.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishTitle", entity.EnglishTitle);
                parameters.Add("@ArabicTitle", entity.ArabicTitle);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@Phone", entity.PhoneNumber);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@Address", entity.Address);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Contact_Proc", parameters, commandType: CommandType.StoredProcedure);

            }
            return entity;
        }

    }
}
