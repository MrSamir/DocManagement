using System.Security.Principal;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DocManagement.Service.Interfaces;
using DocManagement.Service.Models;

namespace DocManagement.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MappingController : ControllerBase
    {
        readonly IMappingService _MappingService;
        public MappingController(IMappingService mappingService)
        {
            _MappingService = mappingService;
        }






        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Select_Mappings_By_KeywordID(int KeywordID)
        {
            var _lst = await _MappingService.GetByKeywordID(KeywordID);

            return Ok(_lst);
        }


        #region "CRUD"
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Select_Mappings()
        {
            var _lst = await _MappingService.GetAll();
            if (_lst.Any())
            {
                return Ok(_lst);
            }

            else
            {
                return  NotFound();
            }
          
        }



        //Add * 
        [Route("[action]")]
        [HttpPost]

        public async Task<IActionResult> Insert_Mapping(Mapping mapping)
        {


            var lst = await _MappingService.Add(mapping);

            return Ok(lst);
        }




        //Delete then select * 
        [Route("[action]")]
        [HttpGet]

        public async Task<IActionResult> Delete_Mapping(int ID)
        {


            var lst = await _MappingService.Delete(ID);

            return Ok(lst);
        }




        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> Update_Mapping(Mapping mapping)
        {

            var IsSucceeded = await _MappingService.Update(mapping);

            return Ok(IsSucceeded);
        }

        #endregion





    }

}