using System.ComponentModel.DataAnnotations;


namespace StackUnderflow.Domain.Schema.Questions.CreateAnswerOp
{
    public class CreateReplyCmd
    {
        public CreateReplyCmd()
        {

        }
        public CreateReplyCmd(int questionId, int authorUserId, int replyId, string body)
        {
            QuestionId = questionId;
            AuthorUserId = authorUserId;
            Body = body;
            ReplyId = replyId;
        }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int AuthorUserId { get; set; }
        [Required]
        public int ReplyId { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Body { get; set; }
    }
}
