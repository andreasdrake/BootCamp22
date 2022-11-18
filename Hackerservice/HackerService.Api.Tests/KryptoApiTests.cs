using AutoFixture;
using FluentValidation;
using FluentValidation.Results;
using HackerService.Api.Models;
using HackerService.Krypto;
using NSubstitute;
using Xunit;

namespace HackerService.Api.Test;

public class KryptoApiTests
{
    public readonly IKrypto _kryptoMock;
    public readonly string _expectedEncrypt;
    public readonly string _expectedDecrypt;
    public readonly IValidator<EncryptRequest> _encryptValidatorMock;
    public readonly IValidator<DecryptRequest> _decryptValidatorMock;
    private readonly Fixture _fixture;

    public KryptoApiTests()
    {
        _fixture = new Fixture();
        _kryptoMock = Substitute.For<IKrypto>();
        _expectedEncrypt = _fixture.Create<string>();
        _expectedDecrypt = _fixture.Create<string>();
        _decryptValidatorMock = Substitute.For<IValidator<DecryptRequest>>();
        _encryptValidatorMock = Substitute.For<IValidator<EncryptRequest>>();
        _kryptoMock.Encrypt(Arg.Any<string>())
            .Returns(_expectedEncrypt);
        _kryptoMock.Decrypt(Arg.Any<string>())
            .Returns(_expectedDecrypt);
        _encryptValidatorMock.Validate(Arg.Any<EncryptRequest>())
            .Returns(new ValidationResult());
        _decryptValidatorMock.Validate(Arg.Any<DecryptRequest>())
            .Returns(new ValidationResult());
    }

    [Fact]
    public void Encrypt_Should_Call_Encrypt_With_Correct_Data()
    {
        // Arrange
        var request = _fixture.Create<EncryptRequest>();
        
        // Act
        KryptoApi.Encrypt(request, _encryptValidatorMock, _kryptoMock);

        // Assert
        _kryptoMock.Received(1).Encrypt(request.Value);
    }

    [Fact]
    public void Decrypt_Should_Call_Decrypt_With_Correct_Data()
    {
        // Arrange
        var request = _fixture.Create<DecryptRequest>();

        // Act
        KryptoApi.Decrypt(request, _decryptValidatorMock, _kryptoMock);

        // Assert
        _kryptoMock.Received(1).Decrypt(request.Value);
    }

    //TODO: add more test for bad request, ok result etc..
}
