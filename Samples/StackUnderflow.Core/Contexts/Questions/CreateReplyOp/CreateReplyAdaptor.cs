using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.CreateAnswerOp.CreateReplyResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.CreateAnswerOp
{
    public class CreateReplyAdaptor : Adapter<CreateReplyCmd, ICreateReplyResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(CreateReplyCmd cmd, ICreateReplyResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICreateReplyResult> Work(CreateReplyCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddAnswerToQuestion(state, CreateAnswerFromCmd(cmd))
                           select t;

            var result =  await workflow.Match(
                Succ: r => r,
                Fail: ex => new ReplyNotCreated(ex.Message)
                );

            return result;
        }

        private ICreateReplyResult AddAnswerToQuestion(QuestionWriteContext state, object v)
        {
            return new ReplyCreated(3, 3, 3, "Raspuns la intrebare");
        }

        private object CreateAnswerFromCmd(CreateReplyCmd cmd)
        {
            return new { };
        }
    }
}
