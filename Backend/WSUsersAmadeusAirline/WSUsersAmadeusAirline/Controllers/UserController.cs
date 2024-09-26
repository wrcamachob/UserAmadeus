using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSUsersAmadeusAirline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersBL<UsersModel> _users;

        public UserController(IUsersBL<UsersModel> userModel)
        {
            this._users = userModel;
        }

        [HttpGet]        
        public async Task<IEnumerable<UsersModel>> Get()
        {
            return await _users.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<IActionResult> Post(UsersModel cliente)
        {
            string message = await _users.Insert(cliente);
            return new JsonResult(message);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(UsersModel cliente)
        {
            string message = await _users.Update(cliente);
            return new JsonResult(message);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Int64 id)
        {
            string message = await _users.Delete(id);
            return new JsonResult(message);
        }
    }
}
