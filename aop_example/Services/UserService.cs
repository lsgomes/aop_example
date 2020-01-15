using aop_example.Model;
using System.Collections.Generic;

namespace aop_example.Services
{
    public class UserService
    {
        readonly List<User> users = new List<User> { new User { Name = "John Doe", Role = Role.STANDARD_USER },
                                                     new User { Name = "Administrator", Role = Role.ADMINISTRATOR }
        };

        public static UserService Instance { get => new UserService(); }

        public User GetUser(string name)
        {
            return users.Find(u => u.Name == name);
        }
    }
}
