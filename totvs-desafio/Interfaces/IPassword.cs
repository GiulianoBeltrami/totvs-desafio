namespace totvs_desafio.Interfaces
{
    public interface IPassword
    {
        public string encrypt(string password);
        public bool compare(string hash, string password);
    }
}
