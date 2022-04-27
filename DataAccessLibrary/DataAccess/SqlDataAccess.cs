using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionID="Default")
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_config.GetConnectionString(connectionID)))
            {
                IEnumerable<T> result = await conn.QueryAsync<T>(sql, parameters);
                return result.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters, string connectionID="Default")
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(_config.GetConnectionString(connectionID)))
            {
                await conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}