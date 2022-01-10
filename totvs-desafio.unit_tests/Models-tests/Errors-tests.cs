using Microsoft.AspNetCore.Mvc;
using System.Net;
using totvs_desafio.Models;
using Xunit;

namespace totvs_desafio_tests.Models_tests
{
    public class Errors_tests
    {
        private ControllerErrors _errors;
        public Errors_tests()
        {
            _errors = new ControllerErrors();
        }

        [Fact]
        public void ExistingEmailError_ShouldReturnObjectResultAndCode409()
        {
            var error = _errors.existingEmailError();

            Assert.IsType<ObjectResult>(error);
            Assert.Equal((int)HttpStatusCode.Conflict, error.StatusCode);
        }

        [Fact]
        public void IncorrectFieldsError__ShouldReturnObjectResultAndCode400()
        {
            var error = _errors.incorrectFieldsError();

            Assert.IsType<ObjectResult>(error);
            Assert.Equal((int)HttpStatusCode.BadRequest, error.StatusCode);
        }

        [Fact]
        public void IncorrectUserEmailError__ShouldReturnObjectResultAndCode404()
        {
            var error = _errors.incorrectUserEmailError();

            Assert.IsType<ObjectResult>(error);
            Assert.Equal((int)HttpStatusCode.NotFound, error.StatusCode);
        }

        [Fact]
        public void IncorrectUserCredentialsError__ShouldReturnObjectResultAndCode401()
        {
            var error = _errors.incorrectUserCredentialsError();

            Assert.IsType<ObjectResult>(error);
            Assert.Equal((int)HttpStatusCode.Unauthorized, error.StatusCode);
        }
    }
}
