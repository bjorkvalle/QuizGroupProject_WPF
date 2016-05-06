using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Models;

namespace Quiz_WPFVersion.ViewModels
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
