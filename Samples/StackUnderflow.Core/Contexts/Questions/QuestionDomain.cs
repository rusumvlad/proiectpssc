using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionOp;
using StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknoledgementOperations;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Schema.Contexts.Questions.CheckLanguageOp.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionOp.CreateQuestionResult;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations.SendQuestionOwnerAcknowledgementResult;


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