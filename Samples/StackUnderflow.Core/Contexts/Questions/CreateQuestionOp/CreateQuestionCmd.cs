using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Schema.Questions.CreateQuestionOp
{
    public class CreateQuestionCmd
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get;  set; }
        [Required]
        public string Body { get;  set; }
        [Required]
        public string Tags { get;  set; }

        public CreateQuestionCmd() { }
        public CreateQuestionCmd(int questionId, string title, string body, string tags)
        {
            QuestionId = questionId;
            Title = title;
            Body = body;
            Tags = tags;
        }
    }
}
