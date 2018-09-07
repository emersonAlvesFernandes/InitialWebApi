using InitialWebApi.Model.Contracts;
using InitialWebApi.Model.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAsync()
            => Ok(await Task.Run(() => _userData.Get()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await Task.Run(() => _userData.GetById(id)));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] User userCreate)
            => Ok(await Task.Run(() => _userData.Add(userCreate)));
    }
}