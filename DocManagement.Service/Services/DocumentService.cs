using DocManagement.DAL;
using DocManagement.Service.Interfaces;
using DocManagement.Service.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocManagement.Service.Services
{
    public class DocumentService : IDocumentService
    {

        readonly IGenericRepo _Repository;

        public DocumentService(IGenericRepo Repository, IConfiguration configuration)
        {
            _Repository = Repository;
            _Repository.Connectionstring = configuration["ConnectionStrings:SQlConn"];
        }
        public Task<IEnumerable<Document>> Add(Document mapping)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Document>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _Repository.GetAll<Document>("DocManagment_SP_Select_Documents");



        }

        public Task<IEnumerable<Document>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Document>> Update(Document mapping)
        {
            throw new NotImplementedException();
        }
    }
}
