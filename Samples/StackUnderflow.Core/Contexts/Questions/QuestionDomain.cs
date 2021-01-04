using Access.Primitives.IO;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations;
using StackUnderflow.Domain.Schema.Questions.CreateQuestionOp;
using StackUnderflow.Domain.Schmea.Questions.CheckLanguageOp;
using static PortExt;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations.SendQuestionOwnerAcknowledgementResult;
using static StackUnderflow.Domain.Schema.Questions.CreateQuestionOp.CreateQuestionResult;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;


namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionContext
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd) =>
            NewPort<CreateQuestionCmd, ICreateQuestionResult>(createQuestionCmd);
        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
            NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);
        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgment(SendQuestionOwnerAcknowledgementCmd cmd) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(cmd);
        public static Port<ICreateReplyResult> CreateReply(CreateReplyCmd createReplyCmd) =>
           NewPort<CreateReplyCmd, ICreateReplyResult>(createReplyCmd);
        public static Port<ISendReplyAuthorAcknowledgementResult> SendReplyAuthorAcknowledgement(SendReplyAuthorAcknowledgementCmd cmd) =>
           NewPort<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult>(cmd);
    }
}