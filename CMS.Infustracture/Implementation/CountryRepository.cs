using CMS.Domain.Entities;
using CMS.Domain.Interfaces;
using CMS.Infustracture.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Infustracture.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDapperContext _context;

        public CountryRepository(ApplicationDapperContext context)
        {
            _context = context;
        }

        public async Task<Country> CreateAsync(Country entity, CancellationToken cancellationToken)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = "INSERT INTO Country (Name, Code) VALUES (@Name, @Code)";
                await db.ExecuteAsync(sql, entity);

                return entity;
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = "SELECT * FROM Country";
                var result = await db.QueryAsync<Country>(sql);

                return result;
            }
        }


    }
}
