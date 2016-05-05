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

        public ObservableCollection<Question> questionList { get; set; }
        public ObservableCollection<Alternative> alternativeList
        {
            get;
            //{
            //    return alternativeList;
            //}
            set;
            //{
            //    alternativeList = value;
            //    PropertyChanged(this, new PropertyChangedEventArgs("alternativeList"));
            //}
        }

        public CreateQuizViewModel()
        {
            questionList = new ObservableCollection<Question>();
            alternativeList = new ObservableCollection<Alternative>();


            alternativeList.Add(new Alternative
            {
                Id = 45,
                Title = "KingKong",
                ScoreValue = 45,
            });

            questionList.Add(new Question
            {
                Id = 45,
                Title = "KingKong",
                Type = Enum.QuestionType.SingleChoiceQuestion,

                Alternatives = new List<Alternative>()
                {
                    new Alternative
                        {
                            Id = 45,
                            Title = "Zorro",
                            ScoreValue = 45,
                        },
                    new Alternative
                    {
                            Id = 45,
                            Title = "Ghost",
                            ScoreValue = 45,

                    },
                }


            });

            questionList.Add(new Question
            {
                Title = "KorreBorre",
                Type = Enum.QuestionType.SingleChoiceQuestion,
                Alternatives = new List<Alternative>(),
            });
            questionList.Add(new Question
            {
                Title = "Fänrik",
                Type = Enum.QuestionType.SingleChoiceQuestion,
                Alternatives = new List<Alternative>(),
            });
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
                Type = Enum.QuestionType.MultiChoiceQuestion,

                Alternatives = new ObservableCollection<Alternative>
                {
                    new Alternative(), new Alternative(),
                },
            });
        }




















        public void AddNewItem(CreateQuiz view)
        {
            questionList.Add(new Question
            {
                Id = 25,
                Title = "KorreBorre",
                Type = Enum.QuestionType.SingleChoiceQuestion,
                Alternatives = new List<Alternative>(),

            });

            //view.listQuestion.ItemsSource = questionList;
        }







    }
}
