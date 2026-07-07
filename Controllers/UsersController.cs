using Microsoft.AspNetCore.Mvc;
using MyBackend.DTOs;
using MyBackend.Services;

namespace MyBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
            => Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserRequest request)
        {
            var user = await _userService.CreateAsync(request);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> Update(int id, [FromBody] UpdateUserRequest request)
        {
            var user = await _userService.UpdateAsync(id, request);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => await _userService.DeleteAsync(id) ? NoContent() : NotFound();
    }
}