using Quiz_WPFVersion.Data;
using Quiz_WPFVersion.View._Shared;
using System.Windows;

namespace Quiz_WPFVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //internal MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            new SeedData();
            MainFrame.Content = new LoginView();

            //Repository<User>.GetInstance().AddData(new User() { Name = "Timmy!" });

            ////using (var db = new QuizContext())
            ////{
            ////    db.Database.Delete();
            ////}

            //User user = new User();
            //user.Name = "Olof";
            //user.Password = "asd";

            //user.Quizs.Add(new Quiz()
            //{
            //    Title = "Quiz1",
            //    Description = "här står det något",
            //    GScore = 60,
            //    VGScore = 80,
            //    StartDate = new DateTime(2015,05,06),
            //    EndDate = new DateTime(2015, 05, 10),
            //    TimeLimit = new TimeSpan(0,0,20),
            //    ShowStudentResult = true,
            //    SentToAdmin = false,
            //    SentToStudent = false,   
            //});

            //Repository<User>.GetInstance().AddData(user);



            ////var quizzes = Repository<Quiz>.GetInstance().GetDataList().Where(quiz => quiz.UserId == Repository<User>.GetInstance().GetData(1).Id);


            //Repository<Question>.GetInstance().AddData(q);

            //Console.WriteLine(q.Alternatives.First().Id + ", " + q.Alternatives.First().QuestionId.ToString());
            //Console.WriteLine(q.Alternatives.ToList()[1].Id + ", " + q.Alternatives.ToList()[1].QuestionId.ToString());
            //Console.WriteLine(q.Alternatives.Last().Id + ", " + q.Alternatives.Last().QuestionId.ToString());
        }
    }
}
