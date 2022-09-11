using System.Collections.Generic;

namespace SISGEP.Application.Models
{
    public class MultipleChoiceQuestion
    {
        public MultipleChoiceQuestion(int order, string text, List<string> answers)
        {
            Order = order;
            Text = text;
            Answers = answers;
        }

        public int Order { get; set; }

        public string Text { get; set; }

        public List<string> Answers { get; set; } = new List<string>();
    }

    public class OpenQuestion
    {
        public OpenQuestion(int order, string text, string answer)
        {
            Order = order;
            Text = text;
            Answer = answer;
        }

        public int Order { get; set; }

        public string Text { get; set; }

        public string Answer { get; set; }
    }
}
