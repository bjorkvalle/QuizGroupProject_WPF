using Quiz_WPFVersion.View.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Quiz_WPFVersion.HelperClass
{
    public class CreateQuestionHelper
    {
        private CreateQuiz crtQuizview { get; set; }
        private static BrushConverter bc = new BrushConverter();



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
        UIElement[] xx = new UIElement[1];

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

            //Get button, and remove button
            Button addButtonAlternative = crtQuizview.gridQuestion.Children.OfType<Button>().FirstOrDefault();
            crtQuizview.gridQuestion.Children.RemoveAt((crtQuizview.gridQuestion.Children.Count - 1));

            //Add alternative and add button
            crtQuizview.gridQuestion.Children.Add(stackOuter);
            crtQuizview.gridQuestion.Children.Add(addButtonAlternative);

        }

    }
}
