using Microsoft.AspNetCore.Mvc;
using TicketsToSkyBd.Operations;
using TicketsToSkyBd.Entities;

namespace TicketsToSkyBd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpPost]
        public ActionResult<User> AddUser([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid) Console.WriteLine("here");
            UserOperations.AddUser(_context, request.ChatId, request.Username, request.FirstName, request.LastName);
            return Ok();
        }

        [HttpGet("{chatId}")]
        public ActionResult<User> GetUser(string chatId)
        {
            var user = UserOperations.GetUser(_context, chatId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }

    public class UserRequest
    {
        public required string ChatId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
