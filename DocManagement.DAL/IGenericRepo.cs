using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.DAL
{
    public interface IGenericRepo
    {
        string Connectionstring { get; set; }
        Task<IEnumerable<T>> GetAll<T>(string storedprocedure);

        Task<IEnumerable<T>> GetAllByParam<T>(string storedprocedure, object parameter);
        Task<T> Get<T>(string storedprocedure);
        Task<T> GetByParam<T>(string storedprocedure, object parameter);
        Task<T> AddRecordQuerySingleRow<T>(string storedprocedure, object parameter);
        Task<int> AddRecordQuerySingle(string storedprocedure, object parameter);
        Task<int> AddRecord(string storedprocedure, object parameter);
        Task<int> AddRecord_ReturnScopeIdentity(string storedprocedure, object parameter);
        Task<int> AddRecords(string storedprocedure, IEnumerable<object> parameter);
        Task<int> Update(string storedprocedure, object parameter);
        Task<int> Delete(string storedprocedure, object parameter);
    }
}
