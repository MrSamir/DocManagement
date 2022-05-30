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
    public class DocumentController : ControllerBase
    {
        readonly IDocumentService _DocumentService;
        public DocumentController(IDocumentService DocumentService)
        {
            _DocumentService = DocumentService;
        }






        #region "CRUD"
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Select_Documents()
        {
            var _lst = await _DocumentService.GetAll();

            return Ok(_lst);
        }



        //Add * 
        [Route("[action]")]
        [HttpPost]

        public async Task<IActionResult> Insert_Document(Document Document)
        {


            var lst = await _DocumentService.Add(Document);

            return Ok(lst);
        }




        //Delete then select * 
        [Route("[action]")]
        [HttpGet]

        public async Task<IActionResult> Delete_Document(int ID)
        {


            var lst = await _DocumentService.Delete(ID);

            return Ok(lst);
        }




        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> Update_Document(Document Document)
        {

            var IsSucceeded = await _DocumentService.Update(Document);

            return Ok(IsSucceeded);
        }

        #endregion





    }

}