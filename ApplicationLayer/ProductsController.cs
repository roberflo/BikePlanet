

using System.Collections.Generic;
using GFShop.Helpers;
using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GFStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductBol _productBol;
      public ProductsController(IProductBol productBol)
        {
            _productBol = productBol;
        }
       
       [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_productBol.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_productBol.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDto productDto)
        {
            
            try
            {
                // save 

                return Ok(_productBol.Create(productDto));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productBol.Delete(id);
            return NoContent();
        }



        
    }
}
