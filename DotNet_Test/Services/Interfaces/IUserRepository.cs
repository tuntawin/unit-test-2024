using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserRepository
    {
        User? GetUserById(int id);
        User CreateUser(User user);
    }
}
