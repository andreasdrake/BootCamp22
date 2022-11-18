namespace HackerService.Krypto.Exceptions;

public class KryptoValidationException : Exception
{
    public KryptoValidationException() : base("Input is not in a correct format")
    {

    }
}
