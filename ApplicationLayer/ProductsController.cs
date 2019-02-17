

using System;
using System.Collections.Generic;
using System.Linq;
using GFShop.ApplicationLayer.Dto.Base;
using GFShop.ApplicationLayer.Dto.Request.Products;
using GFShop.Helpers;
using GFStore.ApplicationLayer.Dto;
using GFStore.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GFStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductBol _productBol;
        private readonly ILogger _logger;
      public ProductsController(IProductBol productBol, ILogger<ProductsController> logger)
        {
            _productBol = productBol;
            _logger = logger;
        }
       
       [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromQuery]ProductParamsDto productParams)
        {
            
            return Ok(_productBol.GetAll(productParams));
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
           
            try
            {
                 _productBol.Delete(id);
                 return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public IActionResult UpdatePrice([FromBody] ChangePricePatchRequest request, int id)
        {
            
            try
            {

                 _productBol.UpdatePrice(request.Price, id);
                 _logger.LogInformation("ChangePrice", "Item {id} to Price {price} Updated", request,id);
                
                 return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("{id}/Like")]
        public IActionResult LikeProduct( int id)
        {
            
            try
            {
                 _productBol.AddLike(id);
                 _logger.LogInformation("Add Like", "Item {id} Liked", id);
                 return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("{id}/MoveInventory")]
        public IActionResult RegisterProductMove([FromBody]InventoryMoveRequest inventoryMove, int id)
        {
            
            try
            {
                 _productBol.InventoryMove(inventoryMove, id);
                 _logger.LogInformation("The ADMIN id: {userId} InventoryMove for product {id} with MovementReference {reference} for {Entry} of {quantity}",
                   GetUserId(), id, inventoryMove.MovementReference, (inventoryMove.Entry)?"Entry":"Exit", inventoryMove.Quantity);

                return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("{id}/Buy")]
        public IActionResult BuyProduc([FromBody]BuyProductRequest inventoryMove, int id)
        {
            
            try
            {
                 _productBol.BuyProduct(inventoryMove, id);
                 _logger.LogInformation("PurchaseDate {date}: The user id: {userId} Buy product {id} with MovementReference {reference} to {Entry}:  {quantity} ",
                   DateTime.Now,GetUserId(), id, inventoryMove.MovementReference,"buy", inventoryMove.Quantity);

                return NoContent();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return NotFound(new { message = ex.Message });
            }
        }


        //Get authorized user id
        protected int GetUserId()
        {
            return int.Parse(this.User.Claims.FirstOrDefault().Value);
        }



    }
}
