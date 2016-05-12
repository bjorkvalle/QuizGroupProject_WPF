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
            userList = new ObservableCollection<User>(Repository<User>.GetInstance().GetDataList());
            educationList = new ObservableCollection<Education>(Repository<Education>.GetInstance().GetDataList());
            courseList = new ObservableCollection<Course>(Repository<Course>.GetInstance().GetDataList());


            #region Design-time Declarations

            //userList = new ObservableCollection<User>
            //{
            //    new User
            //    {
            //        Name = "Haron",
            //    },
            //    new User
            //    {
            //        Name = "Fredrik",
            //    },
            //    new User
            //    {
            //        Name = "Morsid",
            //    },
            //};
            //educationList = new ObservableCollection<Education>
            //{
            //    new Education
            //    {
            //        Name="Java",
            //    },
            //    new Education
            //    {
            //        Name=".Net",
            //    },

            //};
            //courseList = new ObservableCollection<Course>
            //{
            //    new Course
            //    {
            //        Name="Logic"
            //    },
            //    new Course
            //    {
            //        Name="Object"
            //    },
            //    new Course
            //    {
            //        Name="String"
            //    },
            //};

            #endregion
        }

        public void SearchUsers(String searchTerm)
        {
            ResetLabelMessages();
            if (String.IsNullOrEmpty(searchTerm))
            {
                UpdateListViewUser(new ObservableCollection<User>(Repository<User>.GetInstance().GetDataList()));
            }
            else
            {
                UpdateListViewUser(new ObservableCollection<User>(userList.Where(u => u.Name.ToLower().Contains(searchTerm.ToLower())).ToList()));

            }
        }

        private void ResetLabelMessages()
        {
            view.lblMessageSave.Content = "";
            view.lblMessageRemove.Content = "";
        }

        private void UpdateListViewUser(ObservableCollection<User> tempList)
        {
            userList.Clear();
            foreach (var item in tempList)
            {
                userList.Add(item);
            }
        }

        public void RemoveUser(User removeUser)
        {
            var x = removeUser;
            if (removeUser == null) return;
            Repository<User>.GetInstance().DeleteData(removeUser);
            UpdateListViewUser(new ObservableCollection<User>(Repository<User>.GetInstance().GetDataList()));
            view.lblMessageRemove.Content = "• Användaren är nu borttagen.";
            view.lblMessageSave.Content = "";

        }

        public void AddUser()
        {
            ResetLabelMessages();
            var x = userBinding;



            if (String.IsNullOrEmpty(userBinding.Name) || String.IsNullOrEmpty(userBinding.Password)) { view.lblMessageSave.Content = "• Vänligen fyll i namn och lösenord"; return; }
            if (view?.cmbAcess?.SelectedItem == null) { view.lblMessageSave.Content = "• Behörighet måste anges"; return; }

            if (UserExist(userBinding.Name)) { view.lblMessageSave.Content = "• Användarnamnet används redan"; return; }



            UserType selAcess = ConverterEnumType(((ComboBoxItem)view.cmbAcess.SelectedItem).Content.ToString());

            Education tempEdu = (Education)view?.cmbEdu?.SelectedItem;
            List<Course> tempCourse = new List<Course> { (Course)view?.cmbCourse?.SelectedItem };
            string messagePlus = "";
            if (UserType.Admin == selAcess || UserType.Teacher == selAcess)
            {
                tempEdu = null;
                tempCourse = null;
                messagePlus = "Men utan klass eller kurstillhörighet.";
            }
            Repository<User>.GetInstance().AddData
                (
                new User
                {
                    Name = userBinding.Name,
                    Type = selAcess,
                    Courses = tempCourse,
                    Education = tempEdu,
                    Password = userBinding.Password,
                }
                );
            view.lblMessageSave.Content = "• Användaren är nu tillagd. " + messagePlus;

            //Reset
            ClearAllTextBox();
            UpdateListViewUser(new ObservableCollection<User>(Repository<User>.GetInstance().GetDataList()));

        }

        private void ClearAllTextBox()
        {
            view.txtbNamn.Text = "";
            view.txtbPassword.Text = "";
            view.cmbAcess.SelectedIndex = -1;
            view.cmbCourse.SelectedIndex = -1;
            view.cmbEdu.SelectedIndex = -1;
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


        public bool UserExist(string userName)
        {
            User tmp = Repository<User>.GetInstance().GetDataList().Where(user => user.Name == userName).FirstOrDefault();

            return tmp == null ? false : true;
        }

    }
}
