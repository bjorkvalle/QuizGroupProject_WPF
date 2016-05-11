using Quiz_WPFVersion.HelperClass.Command;
using Quiz_WPFVersion.Models;
using Quiz_WPFVersion.View.Teacher;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Quiz_WPFVersion.ViewModels.Teacher
{

    public class CreateQuizViewModel
    {
     
        public ObservableCollection<Question_Binding> questionList { get; set; }
        public Command_Add_Alternative commandAdd_Alternative { get; set; }
        public Command_Remove_Alternative commandRemove_Alternative { get; set; }
        public Command_Remove_Question commandRemove_Question { get; set; }
        public Command_Save_Quiz command_SaveQuiz { get; set; }
        public User activeUser { get; set; }

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
               
                createQuizView.btnSaveQuiz.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                createQuizView.lblMessageBoard.Content = "";
                createQuizView.btnSaveQuiz.Visibility = System.Windows.Visibility.Visible;
            }
        }

        

        public void AddSingelChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "",
                Type = Enum.QuestionType.SingleChoiceQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(), new Alternative(),
                },

            });

        }

        public void AddMultiChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "",
                Type = Enum.QuestionType.MultiChoiceQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(), new Alternative(),
                },
            });
        }

        public void AddRankChoice_Question()
        {
            questionList.Add(new Question_Binding
            {
                Title = "",
                Type = Enum.QuestionType.RankQuestion,
                ScoreValue = 1,
                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(), new Alternative(),
                },
            });
        }

        public void SendInstanceView_ActiveUser(CreateQuiz createQuizView, User activeUser)
        {
            this.createQuizView = createQuizView;
            this.activeUser = activeUser;

        }

    }
}
