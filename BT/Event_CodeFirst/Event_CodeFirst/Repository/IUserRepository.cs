using Event_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_CodeFirst.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(string username);
        void Insert(User user);
        void Update(User user);
        void Delete(string username);
    }
}
