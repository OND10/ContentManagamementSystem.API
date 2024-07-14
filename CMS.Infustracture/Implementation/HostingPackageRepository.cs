using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class HostingPackageRepository : IHostingPackageRepository
    {
        private readonly ApplicationDapperContext _context;
        public HostingPackageRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<HostingPackages> CreateAsync(HostingPackages entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", "CREATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@NumberofHostingPackage", entity.NumberofHostingPackage);
                parameters.Add("@EnCategory", entity.EnCategory);
                parameters.Add("@ArCategory", entity.ArCategory);
                parameters.Add("@BeginPriceMonthly", entity.BeginPriceMonthly);
                parameters.Add("@BeginPriceYearly", entity.BeginPriceYearly);
                parameters.Add("@DiscountPriceMonthly", entity.DiscountPriceMonthly);
                parameters.Add("@DiscountPriceYearly", entity.DiscountPriceYearly);
                parameters.Add("@CpuCapacity", entity.CpuCapacity);
                parameters.Add("@RamCapacity", entity.RamCapacity);
                parameters.Add("@HardDriveCapacity", entity.HardDriveCapacity);
                parameters.Add("@TypeofHard", entity.TypeofHard);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", DateTime.UtcNow);
                parameters.Add("@LastModifiedAt", null);
                parameters.Add("@ModifiedBy", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);

                await db.ExecuteAsync("HostingPackage_Proc", parameters, commandType: CommandType.StoredProcedure);
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

                await db.ExecuteAsync("HostingPackage_Proc", parameters, commandType: CommandType.StoredProcedure);

            }

            return true;
        }

        public Task<IEnumerable<HostingPackages>> FindAllAsync(Expression<Func<HostingPackages, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HostingPackages> FindAsync(Expression<Func<HostingPackages, bool>> expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<R>> FindAsync<R>(Expression<Func<HostingPackages, R>> selector, Expression<Func<HostingPackages, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HostingPackages>> GetAllAsync<R>(Expression<Func<HostingPackages, R>> selector, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<HostingPackages>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryAsync<HostingPackages>($"SELECT * FROM HostingPackage");
                return result;
            }
        }

        public async Task<HostingPackages> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var result = await db.QueryFirstAsync<HostingPackages>($"SELECT * FROM HostingPackage WHERE Id = {id}");
                return result;
            }
        }

        public Task<IEnumerable<HostingPackages>> QueryAsync(string query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<HostingPackages> UpdateAsync(HostingPackages entity, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {

                var getHostingpackage = await db.QueryFirstAsync<HostingPackages>($"SELECT CreatedAt FROM HostingPackage WHERE Id = {entity.Id}");
                entity.CreatedAt = getHostingpackage.CreatedAt;

                var parameters = new DynamicParameters();
                parameters.Add("@Type", "UPDATE");
                parameters.Add("@Id", entity.Id);
                parameters.Add("@EnglishName", entity.EnglishName);
                parameters.Add("@EnglishDescription", entity.EnglishDescription);
                parameters.Add("@ArabicName", entity.ArabicName);
                parameters.Add("@ArabicDescription", entity.ArabicDescription);
                parameters.Add("@NumberofHostingPackage", entity.NumberofHostingPackage);
                parameters.Add("@EnCategory", entity.EnCategory);
                parameters.Add("@ArCategory", entity.ArCategory);
                parameters.Add("@BeginPriceMonthly", entity.BeginPriceMonthly);
                parameters.Add("@BeginPriceYearly", entity.BeginPriceYearly);
                parameters.Add("@DiscountPriceMonthly", entity.DiscountPriceMonthly);
                parameters.Add("@DiscountPriceYearly", entity.DiscountPriceYearly);
                parameters.Add("@CpuCapacity", entity.CpuCapacity);
                parameters.Add("@RamCapacity", entity.RamCapacity);
                parameters.Add("@HardDriveCapacity", entity.HardDriveCapacity);
                parameters.Add("@TypeofHard", entity.TypeofHard);
                parameters.Add("@ImageUrl", entity.ImageUrl);
                parameters.Add("@CreatedAt", entity.CreatedAt);
                parameters.Add("@LastModifiedAt", DateTime.UtcNow);
                parameters.Add("@ModifiedBy", entity.ModifiedBy);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@IsDeleted", null);
                parameters.Add("@DeletedAt", null);

                await db.ExecuteAsync("HostingPackage_Proc", parameters, commandType: CommandType.StoredProcedure);
            }

            return entity;
        }

        public async Task<IEnumerable<HostingPackages>> GetHostingPackagesAsync(string lang, CancellationToken cancellationToken)
        {
            using (IDbConnection db = _context.CreateConnection())
            {
                var query = "SELECT * FROM dbo.Get_arabic_hostingPackage(@lang)";
                var result = await db.QueryAsync<HostingPackages>(query, new { lang });

                return result;
            }
        }
    }
}
