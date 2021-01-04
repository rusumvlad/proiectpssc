using System.Threading.Tasks;
using Access.Primitives.IO;
using Access.Primitives.Extensions.ObjectExtensions;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Schema.Questions.CreateQuestionOp;
using static StackUnderflow.Domain.Schema.Questions.CreateQuestionOp.CreateQuestionResult;


namespace StackUnderflow.Domain.Adapters.Questions.CreateQuestionOp
{
      class CreateQuestionAdapter : Adapter<CreateQuestionCmd, ICreateQuestionResult, QuestionWriteContext, QuestionDependencies>
    {
        public async override Task<ICreateQuestionResult> Work(CreateQuestionCmd command, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in command.TryValidate()
                           let t = AddQuestion(state, CreateQuestionFromCmd(command))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: er => new QuestionNotCreated(er.Message)
                );

            return result;
        }

        public ICreateQuestionResult AddQuestion(QuestionWriteContext state, object question)
        {
            return new QuestionCreated(1, "C# question", "Question about C#", "C#");
        }

        public object CreateQuestionFromCmd(CreateQuestionCmd command)
        {
            return new { };
        }

        public override Task PostConditions(CreateQuestionCmd op, ICreateQuestionResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }
    }
}
