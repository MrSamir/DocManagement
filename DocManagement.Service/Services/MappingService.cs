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
    public class MappingService : IMappingService
    {
        readonly IGenericRepo _Repository;

        public MappingService(IGenericRepo Repository, IConfiguration configuration)
        {
            _Repository = Repository;
            _Repository.Connectionstring = configuration["ConnectionStrings:SQlConn"];
        }
        public async Task<IEnumerable<Mapping>> Add(Mapping mapping)
        {



            return await _Repository.GetAllByParam<Mapping>("DocManagment_SP_Insert_Mapping @DocumentID,@KeywordID",
                         new
                         {

                             mapping.DocumentID,
                             mapping.KeywordID

                         });

        }

        public async Task<IEnumerable<Mapping>> Delete(int id)
        {
            return await _Repository.GetAllByParam<Mapping>("DocManagment_SP_Delete_Mapping @MappingID",
             new
             {
                 MappingID = id


             });
        }

        public async Task<IEnumerable<Mapping>> GetAll()
        {
            return await _Repository.GetAll<Mapping>("DocManagment_SP_Select_Mappings");

        }

        public Task<IEnumerable<Mapping>> GetByID(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Mapping>> GetByKeywordID(int KeywordID)
        {
            return await _Repository.GetAllByParam<Mapping>("DocManagment_SP_Select_Mappings_By_Keyword @KeywordID",
              new
              {
                  KeywordID


              });
        }


        public async Task<IEnumerable<Mapping>> Update(Mapping mapping)
        {
            return await _Repository.GetAllByParam<Mapping>("DocManagment_SP_Update_Mapping @MappingID,@DocumentID,@KeywordID",
             new
             {
                 mapping.MappingID,
                 mapping.DocumentID,
                 mapping.KeywordID,

             });
        }
    }
}
