namespace HackerService.UnitTests;

public class KryptoTests
{
    IKrypto _sut;

    public KryptoTests()
    {
        _sut = new Krypto.Krypto();
    }

    [Theory]
    [InlineData("data lite data", "ZGF0YSBsaXRlIGRhdGE=")]
    [InlineData("lite annan data", "bGl0ZSBhbm5hbiBkYXRh")]
    public void Encrypt_ShouldEncryptCorrectly_ForDifferentValues(string value, string expectedValue)
    {
        var actualValue = _sut.Encrypt(value);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("ZGF0YSBsaXRlIGRhdGE=", "data lite data")]
    [InlineData("bGl0ZSBhbm5hbiBkYXRh", "lite annan data")]
    public void Decrypt_ShouldDeryptCorrectly_ForDifferentValues(string value, string expectedValue)
    {
        var actualValue = _sut.Decrypt(value);

        Assert.Equal(expectedValue, actualValue);
    }
}