using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using totvs_desafio.Controllers;
using totvs_desafio.Models;
using Xunit;

namespace totvs_desafio_integration_tests.Controllers_tests
{
    public class RegistrationControllerTests : IClassFixture<TestFixture>
    {
        [Fact]
        public async Task Get_ShouldReturnEmptyAllUsers()
        {
            var user = new User();
            user.email = "teste@teste.com";
            user.name = "teste";

            var profile = new List<Profile>();
            profile.Add(new Profile() { profession="developer", interests="airplane" });

            user.profile = profile;
            user.password = "123";

            var stringContent = new StringContent(JsonConvert.SerializeObject(user));
            await _testClient.PostAsync("/api/registration", stringContent);

            var response = await _testClient.GetAsync("/api/registration");

            Assert.Null(response);
        }

        //[Fact]
        //public async Task Post_ShouldReturnUserCreated()
        //{
        //    var user = new User();
        //    user.email = "teste@teste.com";
        //    user.name = "teste";

        //    var profile = new List<Profile>();
        //    profile.Add(new Profile() { address = "paulista", age = "12", rg = "123", cpf = "321" });

        //    user.profile = profile;
        //    user.password = "123";


        //}
    }
}
