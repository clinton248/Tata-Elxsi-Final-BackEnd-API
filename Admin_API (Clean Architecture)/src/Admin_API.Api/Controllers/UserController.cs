using Admin_API.Application.DTOs;
using Admin_API.Application.Gateway;
using Admin_API.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        //  private readonly IProfileDbContext _ProfileDbContext;
        private readonly IUserLogics _UserLogic;

        public UserController(IUserLogics UserLogic)
        {
            _UserLogic = UserLogic;

        }
        [HttpGet]
        [Route("all")]
        //   public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                return Ok(_UserLogic.GetAll());
            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "error", Message = $"No user registered" });
            }
        }
        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditStatus([FromBody] EditDto model)
        {
           // var user = await _ProfileDbContext.Users.FindAsync(model.UserName);
            if (model.UserName == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "error", Message = "User Doesn't Exist" });
            }
            int i = _UserLogic.EditInfo(model);
            if (i == 1)
            {
                return Ok(new Response { Status = "Success", Message = "Edited successfully!!!" });
            }
            else
            {
              return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "error", Message = "Updation Failed" });
            }

        }
    }
}
