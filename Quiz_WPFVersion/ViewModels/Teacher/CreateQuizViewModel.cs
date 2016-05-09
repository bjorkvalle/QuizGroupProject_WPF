using Quiz_WPFVersion.HelperClass.Command;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View.Teacher;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Quiz_WPFVersion.ViewModels.Teacher
{

    //: INotifyPropertyChanged, INotifyCollectionChanged
    public class CreateQuizViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged = delegate { };
        //public event NotifyCollectionChangedEventHandler CollectionChanged = delegate { };

        //public ObservableCollection<Alternative> alternativeList
        //{
        //    get;
        //    //{
        //    //    return alternativeList;
        //    //}
        //    set;
        //    //{
        //    //    alternativeList = value;
        //    //    PropertyChanged(this, new PropertyChangedEventArgs("alternativeList"));
        //    //}
        //}
        public ObservableCollection<Question_Binding> questionList { get; set; }
        public Command_Add_Alternative commandAdd_Alternative { get; set; }
        public Command_Remove_Alternative commandRemove_Alternative { get; set; }
        public Command_Remove_Question commandRemove_Question { get; set; }
        public Command_Save_Quiz command_SaveQuiz { get; set; }

        public CreateQuiz createQuizView { get; set; }

        public CreateQuizViewModel()
        {
            questionList = new ObservableCollection<Question_Binding>();
            questionList.CollectionChanged += QuestionList_CollectionChanged;
            commandAdd_Alternative = new Command_Add_Alternative(this);
            commandRemove_Alternative = new Command_Remove_Alternative(this);
            commandRemove_Question = new Command_Remove_Question(this);
            command_SaveQuiz = new Command_Save_Quiz(this);
        }

        private void QuestionList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (questionList.Count == 0)
            {
                if (createQuizView.btnSaveQuiz.Visibility != System.Windows.Visibility.Hidden)
                {
                    createQuizView.BeginStoryboard((Storyboard)createQuizView.FindResource("Save_animation_hide"));
                }
                createQuizView.btnSaveQuiz.Visibility = System.Windows.Visibility.Hidden;
                createQuizView.BeginStoryboard((Storyboard)createQuizView.FindResource("ListBox_hide"));
            }
            else
            {
                if (createQuizView.btnSaveQuiz.Visibility == System.Windows.Visibility.Hidden)
                {
                    if (questionList.Count == 1)
                    {
                        createQuizView.BeginStoryboard((Storyboard)createQuizView.FindResource("ListBox_show"));

                    }

                    createQuizView.BeginStoryboard((Storyboard)createQuizView.FindResource("Save_animation_show"));
                    createQuizView.btnSaveQuiz.Visibility = System.Windows.Visibility.Visible;
                }

                createQuizView.lblMessageBoard.Content = "";

            }

        }

        public void AddSingelChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "Singel Choice",
                Type = Enum.QuestionType.SingleChoiceQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(),
                },

            });

        }

        public void AddMultiChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "Multi Choice",
                Type = Enum.QuestionType.MultiChoiceQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(),
                },
            });
        }

        public void AddRankChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "Rank Choice",
                Type = Enum.QuestionType.RankQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(),
                },
            });
        }

        public void SendInstanceView(CreateQuiz createQuizView)
        {
            this.createQuizView = createQuizView;
        }

    }
}
