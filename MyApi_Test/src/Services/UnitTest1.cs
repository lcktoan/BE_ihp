namespace MyApi_Test;

using MyApi.src.Entities;
using MyApi.src.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var inMemorySettings = new Dictionary<string, string> {
            {"JwtSettings:Secret", "supersecretkeysupersecretkey123!"},
            {"JwtSettings:ExpirationMinutes", "60"},
            {"JwtSettings:Issuer", "TestIssuer"},
            {"JwtSettings:Audience", "TestAudience"}
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var userAuthorService = new UserAuthorService(configuration);
        var service = new UserAuthorService(configuration);

        string username = "testuser";
        string roles = "Admin";
        string email = "test@example.com";

        // Act
        var token = service.GenerateToken(username, roles, email);

        // Assert
        Assert.False(string.IsNullOrEmpty(token));
        // Optionally: Validate the token structure
        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        Assert.True(handler.CanReadToken(token));
        var jwtToken = handler.ReadJwtToken(token);
        Assert.Equal(username, jwtToken.Claims.First(c => c.Type == "unique_name").Value);
        Assert.Equal(roles, jwtToken.Claims.First(c => c.Type == "role").Value);
        Assert.Equal(email, jwtToken.Claims.First(c => c.Type == "email").Value);
    }
}