using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SundayTech_Assignment_StudentAPI.Services
{
    public interface IDapper
    {
        DbConnection GetDbconnection();
        Task<object> Execute<T>(string query, DynamicParameters parameters, CommandType commandType = CommandType.StoredProcedure, bool isSingleRecord = false);
    }
}