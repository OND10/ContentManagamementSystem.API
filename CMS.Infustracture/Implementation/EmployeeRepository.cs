using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System.Data;
using System.Linq.Expressions;

namespace CMS.Infustracture.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDapperContext _context;
        public EmployeeRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@ArabicFullName", entity.ArabicFullName);
                parameters.Add("@EnglishFullName", entity.EnglishFullName);
                parameters.Add("@ArPosition", entity.ArPosition);
                parameters.Add("@EnPosition", entity.EnPosition);
                parameters.Add("@Location", entity.Location);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Department", entity.Department);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Employee_Proc", parameters, commandType: CommandType.StoredProcedure);

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

                await db.ExecuteAsync("Employee_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public Task<IEnumerable<Employee>> FindAllAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> FindAsync(Expression<Func<Employee, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<Employee, R>> selector, Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync<R>(Expression<Func<Employee, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<Employee>($"SELECT * FROM Employee");
                return result;
            }
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<Employee>($"SELECT * FROM Employee WHERE Id = {id}");
                return result;
            }
        }

        public Task<IEnumerable<Employee>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateAsync(Employee entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var getEmployee = await db.QueryFirstAsync<Employee>($"SELECT CreatedAt FROM Employee WHERE Id = {entity.Id}");
                entity.CreatedAt = getEmployee.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@ArabicFullName", entity.ArabicFullName);
                parameters.Add("@EnglishFullName", entity.EnglishFullName);
                parameters.Add("@ArPosition", entity.ArPosition);
                parameters.Add("@EnPosition", entity.EnPosition);
                parameters.Add("@Location", entity.Location);
                parameters.Add("@Email", entity.Email);
                parameters.Add("@PhoneNumber", entity.PhoneNumber);
                parameters.Add("@Department", entity.Department);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);


                await db.ExecuteAsync("Employee_Proc", parameters, commandType: CommandType.StoredProcedure);

            }
            return entity;
        }

    }
}
