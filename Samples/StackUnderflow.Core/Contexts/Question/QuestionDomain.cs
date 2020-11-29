using System;
using System.Collections.Generic;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp.CreateQuestionResult;
using static PortExt;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
    public static class QuestionDomain
    {
        public static Port<ICreateQuestionResult> CreateQuestion(CreateQuestionCmd command)
        {
            return NewPort<CreateQuestionCmd, ICreateQuestionResult>(command);
        }
    }
}
