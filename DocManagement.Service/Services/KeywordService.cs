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
    public class KeywordService : IKeywordService
    {
        readonly IGenericRepo _Repository;

        public KeywordService(IGenericRepo Repository, IConfiguration configuration)
        {
            _Repository = Repository;
            _Repository.Connectionstring = configuration["ConnectionStrings:SQlConn"];
        }
        public async Task<IEnumerable<Keyword>> Add(string Name)
        {
            return await _Repository.GetAllByParam<Keyword>("DocManagment_SP_Insert_Keyword @Name", new
            {
                Name


            });
        }

        public Task<IEnumerable<Keyword>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Keyword>> GetAll()
        {
            return await _Repository.GetAll<Keyword>("DocManagment_SP_Select_Keywords");
        }

        public Task<IEnumerable<Keyword>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Keyword>> Update(Keyword mapping)
        {
            throw new NotImplementedException();
        }
    }
}
