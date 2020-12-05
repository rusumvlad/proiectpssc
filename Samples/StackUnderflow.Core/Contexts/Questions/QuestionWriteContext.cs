using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionWriteContext
    {
        public ICollection<Question> Questions { get; }
        public QuestionWriteContext(ICollection<Question> questions)
        {
            Questions = questions ?? new List<Question>();
        }
    }
}
