using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TournamentApi.Models;

namespace TournamentApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
      private readonly UserContext _context;

      public UserController(UserContext context)
      {
        _context = context;
        if (_context.Users.Count() == 0)
        {
          // create user if collection is empty
          _context.Users.Add(new User {
            FirstName = "Anthony",
            LastName = "Scinocco"
          });

          _context.SaveChanges();
        }
      }

      [HttpGet]
      public ActionResult<List<User>> GetAll()
      {
        return _context.Users.ToList();
      }

      [HttpGet("{id}", Name = "GetUser")]
      public ActionResult<User> GetById(long id)
      {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return user;
      }
    }
}
