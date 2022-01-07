using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
        [Produces("application/json")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var userList = _context.Users;
            return Ok(userList);
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult Post(User user)
        {

            if (isExistingEmail(user.email))
            {
                var Error = new Error();
                Error.message = "Email já cadastrado";

                return StatusCode(303, Error);
            }

            int workfactor = 10;

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(user.password, salt);
            user.password = hash;


            if (user.LastAccessed == null)
            {
                user.LastAccessed = user.created;
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.ID }, user);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
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
            var user = _context.Users.Where(element => element.email == email).Any();
            if (!user)
            {
                return false;
            }
            return true;
        }

        private bool PasswordCompare(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
