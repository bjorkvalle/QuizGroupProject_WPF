using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Quiz_StudentApp.Models
{
    public class QuizTimer
    {
        public TimeSpan TimeLeft { get; set; }
        private TimeSpan _endTime;
        private DispatcherTimer timer = new DispatcherTimer();

        public QuizTimer(TimeSpan quizTimeSpan)
        {
            _endTime = DateTime.Now.TimeOfDay + quizTimeSpan;
            SetTimer();
        }

        private void SetTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            TimeLeft = (_endTime - DateTime.Now.TimeOfDay).Duration();
            
            if (TimeLeft <= new TimeSpan(0, 0, 0))
                timer.Stop();
        }
    }
}
