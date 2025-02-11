namespace Main.Infrastructure.Services.Abstractions
{
    public interface IHasherService
    {
        public string Hash(string input);
        public bool Verify(string input, string hashString);
    }
}
