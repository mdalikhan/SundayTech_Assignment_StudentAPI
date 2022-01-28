using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.Services
{
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;
        private readonly string Connectionstring = "DefaultConnection";

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }
        public async Task<object> Execute(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var resultQuery = db.QueryAsync<object>(query, parameters, commandType: commandType).Result.ToList();

                    tran.Commit();

                    return resultQuery;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }
    }
}
