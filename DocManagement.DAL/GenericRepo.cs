using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.DAL
{
    public class GenericRepo : IGenericRepo
    {
        private string? _connectionstring;
        public string Connectionstring { set { _connectionstring = value; } get { return _connectionstring; } }


        public async Task<IEnumerable<T>> GetAll<T>(string storedprocedure)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return await conn.QueryAsync<T>(storedprocedure);
            }
        }

        public async Task<IEnumerable<T>> GetAllByParam<T>(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                var data = await conn.QueryAsync<T>(storedprocedure, parameter);
                return data;
            }
        }

        public async Task<T> Get<T>(string storedprocedure)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                var data = await conn.QueryFirstOrDefaultAsync<T>(storedprocedure);
                return data;
            }
        }
        public async Task<T> GetByParam<T>(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                var data = await conn.QueryFirstOrDefaultAsync<T>(storedprocedure, parameter);
                return data;
            }
        }



        //to be checked

        public async Task<T> AddRecordQuerySingleRow<T>(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                var data = await conn.QuerySingleAsync<T>(storedprocedure, parameter);
                return data;
            }
        }

        public async Task<int> AddRecordQuerySingle(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                int ret = await conn.QuerySingleAsync<int>(storedprocedure, parameter);
                return ret;
            }
        }
        public async Task<int> AddRecord(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return await conn.ExecuteAsync(storedprocedure, parameter);
            }
        }



        public async Task<int> AddRecord_ReturnScopeIdentity(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return (int)await conn.ExecuteScalarAsync(storedprocedure, parameter);
            }
        }
        public async Task<int> AddRecords(string storedprocedure, IEnumerable<object> parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return await conn.ExecuteAsync(storedprocedure, parameter);
            }
        }

        public async Task<int> Update(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return await conn.ExecuteAsync(storedprocedure, parameter);
            }
        }

        public async Task<int> Delete(string storedprocedure, object parameter)
        {
            using (IDbConnection conn = new SqlConnection(Connectionstring))
            {
                return await conn.ExecuteAsync(storedprocedure, parameter);
            }
        }

    }
}
