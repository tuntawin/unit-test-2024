using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepository _userDataService;

        public UserService(IUserRepository userDataService)
        {
            _userDataService = userDataService;
        }

        public User? GetUserById(int id)
        {
            return _userDataService.GetUserById(id);
        }

        public User CreateUser(User user)
        {
            return _userDataService.CreateUser(user);
        }
    }
}
