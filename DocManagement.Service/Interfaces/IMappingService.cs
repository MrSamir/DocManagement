using DocManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Interfaces
{
    public interface IMappingService
    {


        Task<IEnumerable<Mapping>> GetAll();

        Task<IEnumerable<Mapping>> GetByID(int id);
        Task<IEnumerable<Mapping>> GetByKeywordID(int KeywordID);

        Task<IEnumerable<Mapping>> Add(Mapping mapping);

        Task<IEnumerable<Mapping>> Delete(int id);


        Task<IEnumerable<Mapping>> Update(Mapping mapping);


    }
}
