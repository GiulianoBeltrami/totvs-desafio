using Microsoft.AspNetCore.Mvc;

namespace totvs_desafio.Interfaces
{
    public interface IControllerErrors
    {
        public ObjectResult existingEmailError();

        public ObjectResult incorrectFieldsError();

        public ObjectResult incorrectUserEmailError();

        public ObjectResult incorrectUserCredentialsError();
    }
}
