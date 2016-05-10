using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.View.Admin;

namespace Quiz_WPFVersion.ViewModels.Admin
{

    public class AddRemoveViewModel
    {
        public User userBinding { get; set; }
        public ObservableCollection<Education> educationList { get; set; }
        public ObservableCollection<Course> courseList { get; set; }
        public ObservableCollection<User> userList { get; set; }
        AddRemoveUsers view;


        public AddRemoveViewModel()
        {
            userBinding = new User();

            #region declaration
            //educationList = new ObservableCollection<Education>( Repository<Education>.GetInstance().GetDataList());
            //courseList = new ObservableCollection<Course>( Repository<Course>.GetInstance().GetDataList());
            userList = new ObservableCollection<User>
            {
                new User
                {
                    Name = "Haron",
                },
                new User
                {
                    Name = "Fredrik",
                },
                new User
                {
                    Name = "Morsid",
                },
            }; 
            educationList = new ObservableCollection<Education>
            {
                new Education
                {
                    Name="Java",
                },
                new Education
                {
                    Name=".Net",
                },

            };
            courseList = new ObservableCollection<Course>
            {
                new Course
                {
                    Name="Logic"
                },
                new Course
                {
                    Name="Object"
                },
                new Course
                {
                    Name="String"
                },
            };

            #endregion
        }

        public void SearchUsers(String searchTerm)
        {

        }

        public void RemoveUser(User removeUser)
        {
            var x = removeUser;
        }

        public void AddUser()
        {
            view.lblMessageSave.Content = null;
            var x = userBinding;

            //Måste kontrollera Enum

            if (userBinding.Name == "" || userBinding.Password == ""){view.lblMessageSave.Content = "• Vänligen fyll i namn och lösenord";}
            var selAcess = view?.cmbAcess?.SelectedItem;
            if (selAcess == null) { view.lblMessageSave.Content = "• Behörighet måste anges"; return; } 
            var selCourse = view?.cmbCourse?.SelectedItem;
            var selEdu = view?.cmbEdu?.SelectedItem;

            var us=  new User
            {
                Name = userBinding.Name,
                
            };

        }

        public void GetInstanceView(AddRemoveUsers view)
        {
            this.view = view;
        }
    }
}
