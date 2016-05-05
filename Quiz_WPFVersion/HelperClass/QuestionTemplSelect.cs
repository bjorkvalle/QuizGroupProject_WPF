using Quiz_WPFVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_WPFVersion.HelperClass
{
    public class QuestionTemplSelect : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var question = item as Question;
            FrameworkElement element = container as FrameworkElement;
            if (question == null || element == null) return null;

            DataTemplate template = element.FindResource(question.Type.ToString()) as DataTemplate;

            return template;
        }

    }

}
