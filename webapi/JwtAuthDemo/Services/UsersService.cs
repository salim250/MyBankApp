using System.Collections.Generic;
using System.Linq;
using JwtAuthDemo.Data;
using JwtAuthDemo.Models;
using Microsoft.Extensions.Logging;

namespace JwtAuthDemo.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext dataContext, ILogger<UserService> logger)
        {
            _logger = logger;
            _context = dataContext;
        }

        private readonly ILogger<UserService> _logger;


        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            { "admin", "admin" },
            { "client", "client" },
            { "agent", "agent" },
            { "chefagence", "chefagence" }
        };
        // inject your database here for user validation
        

        public bool IsValidUserCredentials(string email, string password)
        {
            _logger.LogInformation($"Validating user [{email}]");
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }
            List<User> Users = _context.User.ToList();
            var p = Users.Where(c => c.Email == email).ToList();
            return p[0].password == password;
        }

        public bool IsAnExistingUser(string email)
        {
            List<User> Users = _context.User.ToList();
            
            return Users.Exists(c=> c.Email == email);
        }

        public string GetUserRole(string email)
        {
            List<User> Users = _context.User.ToList();
            var p = Users.Where(c => c.Email == email).ToList();
            if (!IsAnExistingUser(email))
            {
                return string.Empty;
            }

            return p[0].role.ToString();
        }
    }

    /*public static class UserRoles
    {
        public const string Admin = nameof(Admin);
        public const string Client = nameof(Client);
        public const string Agent = nameof(Agent);
        public const string Chef = nameof(Chef);
    }*/
}
