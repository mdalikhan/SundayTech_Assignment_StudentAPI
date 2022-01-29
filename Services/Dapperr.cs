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
        public async Task<object> Execute<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, bool isSingleRecord = false)
        {
            using IDbConnection db = GetDbconnection();
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    var resultQuery = db.Query<T>(query, parameters, commandType: commandType, transaction : tran);

                    tran.Commit();

                    if (isSingleRecord)
                    {
                        return resultQuery.AsEnumerable().FirstOrDefault();
                    }
                    else
                    {
                        return resultQuery.AsEnumerable().ToList();
                    }
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
