using System.Collections.Generic;
using totvs_desafio.Models;
using Xunit;

namespace totvs_desafio_tests.Models_tests
{
    public class Validations_tests
    {
        [Fact]
        public void RegistrationFieldsFilled_ShouldReturnTrue()
        {
            var user = new User();
            user.email = "teste@teste.com";
            user.name = "teste";
            var profile = new List<Profile>();
            profile.Add(new Profile() { address = "paulista", age = "12", rg = "123", cpf = "321" });
            user.profile = profile;
            user.password = "123";

            Validations validations = new Validations(user);
            var isFieldsFilled = validations.isRegistrationFieldsFilled();

            Assert.True(isFieldsFilled);
        }

        [Fact]
        public void LoginFieldsFilled_ShouldReturnTrue()
        {
            var user = new User();
            user.email = "teste@teste.com";
            user.password = "123";

            Validations validations = new Validations(user);
            var isFieldsFilled = validations.isLoginFieldsFilled();

            Assert.True(isFieldsFilled);
        }

        [Fact]
        public void LastAccessedFilled_ShouldReturnTrue()
        {
            var user = new User();
            user.email = "teste@teste.com";
            user.LastAccessed = System.DateTime.Now;

            Validations validations = new Validations(user);
            var isFieldsFilled = validations.isLastAccessedFilled();

            Assert.True(isFieldsFilled);
        }
    }
}
