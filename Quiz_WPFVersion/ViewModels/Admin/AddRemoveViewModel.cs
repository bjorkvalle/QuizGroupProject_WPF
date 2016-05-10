using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.View.Admin;
using Quiz_WPFVersion.Enum;
using System.Windows.Controls;

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
            var x = userList.Where(u => u.Name.ToLower().Contains(searchTerm.ToLower()));

            //userList = new ObservableCollection<User>(


            //ItemCollection x = view.listUsers.Items;


            //    ListViewItem foundItem =
            //view.listUsers.FindItemWithText(searchTerm, false, 0, true);
            //    if (foundItem != null)
            //    {
            //        view.listUsers.TopItem = foundItem;

            //    }

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

            if (String.IsNullOrEmpty(userBinding.Name) || String.IsNullOrEmpty(userBinding.Password)) { view.lblMessageSave.Content = "• Vänligen fyll i namn och lösenord"; return; }
            if (view?.cmbAcess?.SelectedItem == null) { view.lblMessageSave.Content = "• Behörighet måste anges"; return; }


            UserType selAcess = ConverterEnumType(((ComboBoxItem)view.cmbAcess.SelectedItem).Content.ToString());

            //var selCourse = view?.cmbCourse?.SelectedItem;
            //var selEdu = view?.cmbEdu?.SelectedItem;

            //var us = new User
            //{
            //    Name = userBinding.Name,
            //    Type = selAcess,
            //    Courses = new List<Course> { (Course)view?.cmbCourse?.SelectedItem },
            //    Education = (Education)view?.cmbEdu?.SelectedItem,
            //    Password = userBinding.Password,
            //};
            Repository<User>.GetInstance().AddData
                (
                new User
                {
                    Name = userBinding.Name,
                    Type = selAcess,
                    Courses = new List<Course> { (Course)view?.cmbCourse?.SelectedItem },
                    Education = (Education)view?.cmbEdu?.SelectedItem,
                    Password = userBinding.Password,
                }
                );
            view.lblMessageSave.Content = "• Användaren är nu tillagd";

            //resetta alla boxes och uppdatera lisViewn
        }

        private UserType ConverterEnumType(String selectedItem)
        {
            switch (selectedItem)
            {
                case "Lärare":
                    return UserType.Teacher;
                case "Admin":
                    return UserType.Admin;
                default:
                    //Student
                    return UserType.Student;
            }
        }

        public void GetInstanceView(AddRemoveUsers view)
        {
            this.view = view;
        }
    }
}
