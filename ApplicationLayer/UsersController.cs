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
    public class UsersController : ControllerBase
    {
        private IUserBol _userBol;
      
        public UsersController(IUserBol userBol)
        {
            _userBol = userBol;
        }
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_userBol.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_userBol.GetById(id));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RegisterUser([FromBody]UserDto userDto)
        {
            
            try
            {
                // save 

                return Ok(_userBol.CreateUser(userDto));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("Admin")]
        public IActionResult RegisterAdmin([FromBody]UserDto userDto)
        {

            try
            {
                // save 

                return Ok(_userBol.CreateUser(userDto));
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {
            var user = _userBol.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
