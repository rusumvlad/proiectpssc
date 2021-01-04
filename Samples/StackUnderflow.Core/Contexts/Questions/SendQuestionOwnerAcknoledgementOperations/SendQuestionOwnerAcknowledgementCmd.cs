using System.ComponentModel.DataAnnotations;

namespace StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations
{
    public class SendQuestionOwnerAcknowledgementCmd
    {
        [Required]
        public int QuestionId { get; }
        [Required]
        public int QuestionOwnerId { get; }
        public SendQuestionOwnerAcknowledgementCmd(int questionId, int questionOwnerId)
        {
            QuestionId = questionId;
            QuestionOwnerId = questionOwnerId;
        }
    }
}
