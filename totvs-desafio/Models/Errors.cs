using Microsoft.AspNetCore.Mvc;

namespace totvs_desafio.Models
{
    public class Error
    {
        public string message { get; set; }
    }

    public class ControllerErrors : ControllerBase
    {
        public ActionResult existingEmailError()
        {
            var Error = new Error();
            Error.message = "E-mail já existente";
            return StatusCode(303, Error);
        }


        public ActionResult incorrectFieldsError()
        {
            var Error = new Error();
            Error.message = "Preencha os campos corretamente";
            return StatusCode(400, Error);
        }


        public ActionResult incorrectUserEmailError()
        {
            var Error = new Error();
            Error.message = "Usuário e/ou senha inválidos";
            return StatusCode(404, Error);
        }


        public ActionResult incorrectUserCredentialsError()
        {
            var Error = new Error();
            Error.message = "Usuário e/ou senha inválidos";
            return StatusCode(401, Error);
        }
    }



}
