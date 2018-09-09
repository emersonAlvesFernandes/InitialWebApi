using InitialWebApi.Model.Contracts;
using InitialWebApi.Model.Models;
using InitialWebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace InitialWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userData;

        public UserController(IUserRepository userData)
        {
            _userData = userData;
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
            => Ok(await Task.Run(() => _userData.Get()));

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await Task.Run(() => _userData.GetById(id)));

        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostAsync([FromBody] UserCreateViewModel userCreate)
        {
            var user = new User(userCreate.Name, userCreate.Cpf, userCreate.Email);

            return Ok(await Task.Run(() => _userData.Add(user)));
        }
        
    }
}