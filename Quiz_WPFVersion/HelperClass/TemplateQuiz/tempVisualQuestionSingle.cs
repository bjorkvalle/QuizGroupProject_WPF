using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Quiz_WPFVersion.HelperClass.TemplateQuiz
{
    class tempVisualQuestionSingle
    {
        public Question question { get; set; }
        public List<containerAlt> alternativeList { get; set; }


        //Innehåll i en VisualQuestion
        public TextBlock textBlockLabel;
        public TextBox textBoxQ;
        public StackPanel stackInner, stackOuter;
        public Border border;
        public Image image;

        public tempVisualQuestionSingle()
        {
            var converter = new BrushConverter();

            stackOuter = new StackPanel
            {
                Margin = new Thickness(0, 15, 0, 0),
            };

            textBlockLabel = new TextBlock
            {
                TextWrapping = System.Windows.TextWrapping.Wrap,
                FontFamily = new FontFamily("Segoe WP Semibold"),
                Foreground = (Brush)converter.ConvertFromString("#FF464646"),
            };

            stackInner = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            textBoxQ = new TextBox
            {
                TextWrapping = TextWrapping.Wrap,
                MinWidth = 387
            };

            border = new Border
            {
                Width = 50,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Left,
                BorderBrush = (Brush)converter.ConvertFromString("#FFB9B9B9"),
            };

            image = new Image
            {
                Source = new BitmapImage(new Uri(@"/Quiz_WPFVersion;component/Data/Images/1.png", UriKind.RelativeOrAbsolute))
            };

            border.Child = image;

        }

        //Populera en stack

        public StackPanel GetVisualQuestion()
        {
            stackOuter.Children.Add(textBlockLabel);
            stackInner.Children.Add(textBoxQ);
            stackInner.Children.Add(border);
            stackOuter.Children.Add(stackInner);
            return stackOuter;
        }


    }
}
