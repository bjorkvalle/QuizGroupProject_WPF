using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Quiz_StudentApp.Enums;
using Quiz_StudentApp.Models;

namespace Quiz_StudentApp.HelperClass
{
    class QuestionTemplateSelector : DataTemplateSelector
    {

        public DataTemplate SingleChoiceQuestionTemplate { get; set; }
        public DataTemplate MultiChoiceQuestionTemplate { get; set; }
        public DataTemplate RankQuestionTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var question = item as Question;
            if (question.Type == QuestionType.SingleChoiceQuestion)
            {
                return SingleChoiceQuestionTemplate;
            }if (question.Type == QuestionType.MultiChoiceQuestion)
            {
                return MultiChoiceQuestionTemplate;
            }
            if (question.Type == QuestionType.RankQuestion)
            {
                return RankQuestionTemplate;
            }
            return base.SelectTemplate(item, container);


        }
    }
}
