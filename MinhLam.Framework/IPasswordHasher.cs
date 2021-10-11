namespace MinhLam.Framework
{
    public interface IPasswordHasher
    {
        string Hash(string purePassword, string key);
    }
}
