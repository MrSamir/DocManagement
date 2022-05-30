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
    public class KeywordController : ControllerBase
    {
        readonly IKeywordService _KeywordService;
        public KeywordController(IKeywordService KeywordService)
        {
            _KeywordService = KeywordService;
        }






        #region "CRUD"
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Select_Keywords()
        {
            var _lst = await _KeywordService.GetAll();

            return Ok(_lst);
        }



        //Add * 
        [Route("[action]")]
        [HttpGet]

        public async Task<IActionResult> Insert_Keyword(string name)
        {


            var lst = await _KeywordService.Add(name);

            return Ok(lst);
        }




        //Delete then select * 
        [Route("[action]")]
        [HttpGet]

        public async Task<IActionResult> Delete_Keyword(int ID)
        {


            var lst = await _KeywordService.Delete(ID);

            return Ok(lst);
        }




        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> Update_Keyword(Keyword Keyword)
        {

            var IsSucceeded = await _KeywordService.Update(Keyword);

            return Ok(IsSucceeded);
        }

        #endregion





    }

}