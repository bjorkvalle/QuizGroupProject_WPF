﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz_WPFVersion.Models;

namespace Quiz_WPFVersion.ViewModels
{
    class AdminViewModel
    {
        User user = null;

        public void GetUser(User user)
        {
            this.user = user;
        }

    }
}