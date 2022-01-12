using Microsoft.AspNetCore.Mvc;
using totvs_desafio.Database;
using totvs_desafio.Models;
using totvs_desafio.Services;

namespace totvs_desafio.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {

        private ControllerErrors _errors;

        public LoginController(ControllerErrors errors)
        {
            _errors = errors;
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult Login([FromBody] User user)
        {
            Validations validations = new Validations(user);

            if (!validations.isLoginFieldsFilled())
            {
                return _errors.incorrectFieldsError();
            }

            User searchedUser = DapperQuery.getUserByEmail(user.email);

            if (searchedUser == null)
            {
                return _errors.incorrectUserEmailError();
            }

            Password password = new Password();
            var isPasswordCorrect = password.compare(searchedUser.password, user.password);

            if (isPasswordCorrect)
            {
                var tokenString = TokenService.GenerateToken(user);

                var userUpdated = UpdateLastLoginAndUser(user);

                return Ok(new 
                { 
                    user = userUpdated,
                    token = tokenString
                });
            }
            else
            {
                return _errors.incorrectUserCredentialsError();
            }

        }

        private User UpdateLastLoginAndUser(User user)
        {
            DapperQuery.updateLastLogin(user.email);
            User userUpdated = DapperQuery.getUserByEmail(user.email);
            return userUpdated;
        }

    }
}
