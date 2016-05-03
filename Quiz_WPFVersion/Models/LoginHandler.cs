using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Interfaces;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;

namespace Quiz_WPFVersion.Models
{
    class LoginHandler
    {

        public User CheckUserInformation(string username, string password)
        {

            User currentUser = Repository<User>.GetInstance().GetDataList().FirstOrDefault(u => u.Name == username);

            return currentUser != null ? CheckUserPassword(currentUser, password) : null;

        }

        public User CheckUserPassword(User user, string password)
        {
            return user.Password == password ? user : null;
        }



    }
}
