using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Unicam.Paradigmi.Bookshop.Application.Abstractions.Services;
using Unicam.Paradigmi.Bookshop.Application.Options;
using Unicam.Paradigmi.Bookshop.Models.Entities;
using Unicam.Paradigmi.Bookshop.Models.Repositories;

namespace Unicam.Paradigmi.Bookshop.Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtAuthenticationOption _jwtAuthenticationOption;
    private readonly UserRepository _userRepository;

    public TokenService(UserRepository userRepository, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
    {
        _userRepository = userRepository;
        _jwtAuthenticationOption = jwtAuthenticationOption.Value;
    }

    public async Task<string> CreateTokenAsync(string email, string password)
    {
        var user = await _userRepository.GetUserFromEmailAndPassword(email, password);

        if (user == null) throw new InvalidCredentialException("Invalid email or password");

        return CreateJwtToken(user);
    }

    private string CreateJwtToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthenticationOption.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new("user_id", user.Id.ToString()),
            new("Name", user.Name),
            new("Surname", user.Surname),
            new("Email", user.Email)
        };

        var jwtSecurityToken = new JwtSecurityToken(_jwtAuthenticationOption.Issuer,
            null,
            claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}