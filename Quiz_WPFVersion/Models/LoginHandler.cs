using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;

namespace Quiz_WPFVersion.Models
{
    class LoginHandler
    {

        IRepository repo;

        public User CheckUserInformation(string username, string password)
        {

            User currentUser;

            IList<User> users = repo.GetAllUsers();

            currentUser = users.FirstOrDefault(u => u.Name == username);

            if (currentUser != null)
                return CheckUserPassword(currentUser, password);
            else
                return null;

        }

        public User CheckUserPassword(User user, string password)
        {
            if (user.Password == password)
                return user;
            else
                return null;
        }



    }
}
