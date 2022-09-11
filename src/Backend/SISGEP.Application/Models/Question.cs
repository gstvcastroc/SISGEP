using System.Collections.Generic;

namespace SISGEP.Application.Models
{
    public class Question
    {
        public Question(int order, string text, List<string> answers)
        {
            Order = order;
            Text = text;
            Answers = answers;
        }

        public int Order { get; set; }

        public string Text { get; set; }

        public List<string> Answers { get; set; } = new List<string>();
    }
}
