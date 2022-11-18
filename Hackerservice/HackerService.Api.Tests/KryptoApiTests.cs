using AutoFixture;
using FluentValidation;
using HackerService.Api.Models;
using HackerService.Krypto;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace HackerService.Api.Tests
{
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
            _kryptoMock = Substitute.For<IKrypto>();
            _kryptoMock.Encrypt(Arg.Any<string>())
                .Returns(_expectedEncrypt);
            _kryptoMock.Decrypt(Arg.Any<string>())
                .Returns(_expectedDecrypt);
            _encryptValidatorMock.Validate(Arg.Any<EncryptRequest>())
                .Returns(new FluentValidation.Results.ValidationResult());
            _fixture = new Fixture();
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
    }  
}
