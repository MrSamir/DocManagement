using DocManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Interfaces
{
    public interface IKeywordService
    {



        Task<IEnumerable<Keyword>> GetAll();

        Task<IEnumerable<Keyword>> GetByID(int id);

        Task<IEnumerable<Keyword>> Add(string Keyword);

        Task<IEnumerable<Keyword>> Delete(int id);


        Task<IEnumerable<Keyword>> Update(Keyword mapping);

    }
}
