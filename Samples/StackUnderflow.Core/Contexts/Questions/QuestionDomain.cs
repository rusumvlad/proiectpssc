using Access.Primitives.IO;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionOp;
using StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknoledgementOperations;
using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using static StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp.CheckLanguageResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionOp.CreateQuestionResult;
using static StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknoledgementCmd.SendQuestionOwnerAcknowledgementResult;


namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public static class QuestionContext
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd createQuestionCmd) =>
            NewPort<CreateQuestionCmd, ICreateQuestionResult>(createQuestionCmd);
        public static Port<ICheckLanguageResult> CheckLanguage(CheckLanguageCmd checkLanguageCmd) =>
            NewPort<CheckLanguageCmd, ICheckLanguageResult>(checkLanguageCmd);
        public static Port<ISendQuestionOwnerAcknowledgementResult> SendQuestionOwnerAcknowledgment(SendQuestionOwnerAcknowledgementCmd SendQuestionOwnerAcknowledgmentCmd) =>
            NewPort<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult>(SendQuestionOwnerAcknowledgmentCmd);
    }
}