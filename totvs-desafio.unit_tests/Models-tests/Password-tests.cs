using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totvs_desafio.Models;
using Xunit;

namespace totvs_desafio_tests.Models_tests
{
    public class Password_tests
    {
        private Password _password;
        public Password_tests()
        {
            _password = new Password();
        }

        [Fact]
        public void Encrypt_ShouldReturnEncyptedPassword()
        {
            var password = "123";

            var encryptedPassword = _password.encrypt(password);

            Assert.NotEqual(password, encryptedPassword);
        }

        [Fact]
        public void Compare_ShouldReturnTrueWithMatchingPassword()
        {
            var password = "123";
            var encryptedPassword = _password.encrypt(password);

            var isPasswordCorrect = _password.compare(encryptedPassword, password);

            Assert.True(isPasswordCorrect);
        }

        [Fact]
        public void Compare_ShouldReturnFalseWithNotMatchingPassword()
        {
            var password = "123";
            var incorrectPassword = "321";
            var encryptedPassword = _password.encrypt(password);

            var isPasswordCorrect = _password.compare(encryptedPassword, incorrectPassword);

            Assert.False(isPasswordCorrect);
        }
    }
}
