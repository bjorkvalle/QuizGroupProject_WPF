using Quiz_WPFVersion.View.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_WPFVersion.HelperClass
{
    public class CreateQuestionHelper
    {
        private CreateQuiz crtQuizview { get; set; }
        private CreateQuestionHelper()
        {
            throw new ArgumentException("No argument constructor is not allowed");
        }

        /// <summary>
        /// Send  CreateView
        /// </summary>
        /// <param name="view"></param>
        public CreateQuestionHelper(CreateQuiz view)
        {
            crtQuizview = view;
        }

        //TextBox Alternative - SingelQtype
        double
            txtbAltHeight = 18,
            txtbAltWidth = 426,
            txtbAltMinWidth = 175,
            txtbOpacity = 0.5;
        int alternativeCounter;

        public static int radioButtonGroupCounter;

        public void CreateAlternativeSingleQuestionType()
        {
            StackPanel stackOuter = new StackPanel
            {
                Margin = new Thickness(0, 6, 0, 0),
                
            };


            StackPanel stackInner = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                Orientation = Orientation.Horizontal
            };

            TextBox textBox = new TextBox
            {
                //Name = "Alternavite" + alternativeCounter++.ToString(),
                Height = txtbAltHeight,
                Width = txtbAltWidth,
                MinWidth = txtbAltMinWidth,
                Opacity = txtbOpacity
            };

            RadioButton radioButton = new RadioButton
            {
                GroupName = radioButtonGroupCounter.ToString(),
                Margin = new Thickness(10, 2, 0, 0),
            };
            stackInner.Children.Add(textBox);
            stackInner.Children.Add(radioButton);
            stackOuter.Children.Add(stackInner);

            crtQuizview.gridQuestion.Children.Add(stackOuter);
        }

    }
}
