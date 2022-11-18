namespace HackerService.Krypto;

public interface IKrypto
{
    string Encrypt(string value);
    string Decrypt(string value);
}