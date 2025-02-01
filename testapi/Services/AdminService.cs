using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using testapi.Data;
using testapi.DTO;

namespace testapi.Services
{
    public class AdminService : IAdminService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        public AdminService(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<UserLogin> Login(string username, string password)
        {
            User user = await _context.Users.FindAsync(username);
            if (user == null)
            {
                return null;
            }

            if (GetPasswordHash(password, user.Passkey) != user.Password)
            {
                return null;
            }
            UserLogin userLogin = new UserLogin()
            {
                Username = user.Username,
                Token = GenerateJWTToken(user)
            };
            return userLogin;
        }


        async Task<User> IAdminService.Register(UserRegister _user)
        {
            User user = new User();
            if (await _context.Users.FindAsync(_user.Username) != null)
            {
                return null;
            }
            user.Username = _user.Username;
            user.Password = _user.Password;
            user.role = user.role ?? "user";

            user.Passkey = GetNewSalt(); // Generate a new salt
            user.Password = GetPasswordHash(user.Password, user.Passkey); // Generate a new password hash

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        private string GetNewSalt()
        {
            var random = new Random();
            var salt = new byte[32];
            random.NextBytes(salt);
            return Convert.ToBase64String(salt);
        }
        private string GetPasswordHash(string password, string salt = null)
        {
            if (salt == null)
            {
                salt = GetNewSalt();
            }
            string pepper = _config["Pepper"]?.ToString() ?? "pepper";

            password = password + pepper;

            using (var sha256 = new SHA256Managed())
            {
                var bytes = Encoding.UTF8.GetBytes(password + salt);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }

        }

        private string GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("username", user.Username),
                new Claim("role", user.role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}