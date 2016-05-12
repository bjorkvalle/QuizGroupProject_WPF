using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_StudentApp.Models;

namespace Quiz_StudentApp.ViewModels
{
    class LoginViewModel
    { 
    
        LoginHandler loginHandler = new LoginHandler();

        public User LoginControll(string username, string password)
        {
            //If true, grant acess
            return loginHandler.CheckUserInformation(username, password);

        }

    }
}
