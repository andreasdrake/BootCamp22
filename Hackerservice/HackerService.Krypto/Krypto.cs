using System.Text;
using HackerService.Krypto.Exceptions;

namespace HackerService.Krypto;

public class Krypto : IKrypto
{
    public string Decrypt(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new KryptoValidationException();    
        }

        var base64EncodedBytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public string Encrypt(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new KryptoValidationException();
        }

        var textBytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(textBytes, Base64FormattingOptions.InsertLineBreaks);
    }
}
