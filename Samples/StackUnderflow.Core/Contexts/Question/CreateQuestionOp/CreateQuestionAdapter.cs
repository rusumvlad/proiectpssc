using System;
using System.Collections.Generic;
using System.Text;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp.CreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestionOp
{
    public partial class CreateQuestionAdapter : Adapters<CreateQuestionCmd, ICreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
        public async override Task<ICreateQuestionResult> Work(CreateQuestionCmd command, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestion(state, CreateQuestionFromCmd(command))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: er => new QuestionNotCreated(er.reason)
                );

            return result;
        }

        public ICreateQuestionResult AddQuestion(QuestionWriteContext state, Question question)
        {
            return new QuestionCreated(new Guid("1"), "C# question", "Question about C#", "C#");
        }

        public Question CreateQuestionFromCmd(CreateQuestionCmd command)
        {
            return new { };
        }

        public override Task PostConditions(CreateQuestionCmd op, ICreateQuestionResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }
    }
}
