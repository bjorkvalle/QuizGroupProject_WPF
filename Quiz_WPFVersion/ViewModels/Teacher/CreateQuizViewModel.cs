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
        public ObservableCollection<Question> questionList { get; set; }
        public Command_Add_Alternative commandAdd_Alternative { get; set; }
        public Command_Remove_Alternative commandRemove_Alternative { get; set; }
        public Command_Remove_Question commandRemove_Question { get; set; }
        public Command_Save_Quiz command_SaveQuiz { get; set; }

        public CreateQuiz createQuizView { get; set; }

        public CreateQuizViewModel()
        {
            questionList = new ObservableCollection<Question>();
            commandAdd_Alternative = new Command_Add_Alternative(this);
            commandRemove_Alternative = new Command_Remove_Alternative(this);
            commandRemove_Question = new Command_Remove_Question(this);
            command_SaveQuiz = new Command_Save_Quiz(this);
        }


        public void AddSingelChoice_Question()
        {
            questionList.Add(new Question
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
            questionList.Add(new Question
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
            questionList.Add(new Question
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
