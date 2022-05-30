using DocManagement.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Interfaces
{
    public interface IDocumentService
    {


        Task<IEnumerable<Document>> GetAll();

        Task<IEnumerable<Document>> GetByID(int id);

        Task<IEnumerable<Document>> Add(Document mapping);

        Task<IEnumerable<Document>> Delete(int id);


        Task<IEnumerable<Document>> Update(Document mapping);
    }
}
