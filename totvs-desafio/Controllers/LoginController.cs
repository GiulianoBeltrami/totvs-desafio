using Microsoft.AspNetCore.Mvc;
using totvs_desafio.Database;
using totvs_desafio.Models;

namespace totvs_desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private ControllerErrors _errors;

        public LoginController(ControllerErrors errors)
        {
            _errors = errors;
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult Login(User user)
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
                DapperQuery.updateLastLogin(searchedUser.email);
                User userUpdated = DapperQuery.getUserByEmail(searchedUser.email);
                return Ok(userUpdated);
            }
            else
            {
                return _errors.incorrectUserCredentialsError();
            }

        }



    }
}
