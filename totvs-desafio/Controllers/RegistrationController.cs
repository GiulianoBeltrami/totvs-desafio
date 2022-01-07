using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using totvs_desafio.Context;
using totvs_desafio.Models;

namespace totvs_desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private UserContext _context;

        public RegistrationController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userList = _context.Users;
            return Ok(userList);
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {

            if (isExistingEmail(user.email))
            {
                StatusCode(303);
                return new StatusCodeResult(303);
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(long id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        private bool isExistingEmail(string email)
        {
            var user = _context.Users.Find(email);
            if(user == null)
            {
                return false;
            }
            return true;
        }

    }
}
