using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Ferreteria.Application.Services;

public class AuthService
{
    private readonly ICustomerRepository _repo;
    private readonly IConfiguration _config;

    public AuthService(ICustomerRepository repo, IConfiguration config)
    {
        _repo = repo;
        _config = config;
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var customer = await _repo.GetByEmailAsync(email);

        if (customer == null || customer.Password != password)
            return null;

        return GenerateToken(customer);
    }

    private string GenerateToken(Customer customer)
    {
        var jwtSettings = _config.GetSection("Jwt");

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Email, customer.Email),
            new Claim("name", customer.Name)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}