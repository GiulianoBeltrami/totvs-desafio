using Microsoft.AspNetCore.Mvc;
using System.Net;
using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class Error
    {
        public string message { get; set; }
    }

    public class ControllerErrors : ControllerBase, IControllerErrors
    {
        public ObjectResult existingEmailError()
        {
            var Error = new Error();
            Error.message = "E-mail já existente";
            return StatusCode((int)HttpStatusCode.Conflict, Error);
        }


        public ObjectResult incorrectFieldsError()
        {
            var Error = new Error();
            Error.message = "Preencha os campos corretamente";
            return StatusCode((int)HttpStatusCode.BadRequest, Error);
        }


        public ObjectResult incorrectUserEmailError()
        {
            var Error = new Error();
            Error.message = "Usuário e/ou senha inválidos";
            return StatusCode((int)HttpStatusCode.NotFound, Error);
        }


        public ObjectResult incorrectUserCredentialsError()
        {
            var Error = new Error();
            Error.message = "Usuário e/ou senha inválidos";
            return StatusCode((int)HttpStatusCode.Unauthorized, Error);
        }
    }



}
