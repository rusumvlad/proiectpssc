using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionWriteContext
    {
        public ICollection<Question> Questions { get; }
        public ICollection<Reply> Replies { get; }
        public QuestionWriteContext(ICollection<Question> questions)
        {
            Questions = questions ?? new List<Question>();
        }

        public QuestionWriteContext(ICollection<Reply> replies)
        {
            Replies = replies ?? new List<Reply>();
        }
    }
}
