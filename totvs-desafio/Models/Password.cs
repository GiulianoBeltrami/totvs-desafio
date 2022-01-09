using totvs_desafio.Interfaces;

namespace totvs_desafio.Models
{
    public class Password : IPassword
    {
        public string encrypt(string password)
        {
            int workfactor = 10;

            string salt = BCrypt.Net.BCrypt.GenerateSalt(workfactor);
            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        public bool compare(string hash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
