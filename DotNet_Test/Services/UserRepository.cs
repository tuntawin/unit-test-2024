using Database;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            var lastId = _context.Users.Max(u => u.Id);
            user.Id = lastId + 1;

            _context.Users.Add(user);
            return user;
        }

        public User? GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == 1);
            return user;
        }
    }
}
