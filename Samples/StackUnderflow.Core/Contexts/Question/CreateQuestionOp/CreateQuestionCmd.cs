using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp
{
    public class CreateQuestionCmd
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Body { get; private set; }
        [Required]
        public string[] Tags { get; private set; }

        public CreateQuestionCmd(string title, string body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}
