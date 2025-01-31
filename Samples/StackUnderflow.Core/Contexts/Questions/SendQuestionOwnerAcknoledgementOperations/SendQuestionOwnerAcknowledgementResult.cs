﻿using CSharp.Choices;

namespace StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations
{
    [AsChoice]
    public static partial class SendQuestionOwnerAcknowledgementResult
    {
        public interface ISendQuestionOwnerAcknowledgementResult { }

        public class AcknowledgementSent : ISendQuestionOwnerAcknowledgementResult
        {
            public int QuestionId { get; }
            public int QuestionOwnerId { get; }
            public AcknowledgementSent(int questionId, int questionOwnerId)
            {
                QuestionId = questionId;
                QuestionOwnerId = questionOwnerId;
            }
        }

        public class AcknowledgmentNotSent : ISendQuestionOwnerAcknowledgementResult
        {
            public string Message { get; }
            public AcknowledgmentNotSent(string message)
            {
                Message = message;
            }
        }
    }
}
