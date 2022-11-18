namespace HackerService.UnitTests;

public class KryptoTests
{
    readonly IKrypto _sut;

    public KryptoTests()
    {
        _sut = new Krypto.Krypto();
    }

    [Theory]
    [InlineData(null!)]
    [InlineData("")]
    public void Encrypt_ShouldThrowCorrectException_WhenInputIsInvalid(string value)
    {
        Assert.Throws<KryptoValidationException>(() => _sut.Encrypt(value));
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
    [InlineData(null!)]
    [InlineData("")]
    [InlineData(" ")]
    public void Decrypt_ShouldThrowCorrectException_WhenInputIsInvali(string value)
    {
        Assert.Throws<KryptoValidationException>(() => _sut.Decrypt(value));
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