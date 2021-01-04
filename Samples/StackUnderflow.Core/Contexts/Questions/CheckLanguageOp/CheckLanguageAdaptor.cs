using Access.Primitives.IO;
using System.Threading.Tasks;
using StackUnderflow.Domain.Schmea.Questions.CheckLanguageOp;
using static StackUnderflow.Domain.Schema.Questions.CheckLanguageOp.CheckLanguageResult;
using StackUnderflow.Domain.Core.Contexts.Questions;

namespace StackUnderflow.Domain.Adapters.Questions.CheckLanguageOp
{
    public class CheckLanguageAdaptor : Adapter<CheckLanguageCmd, ICheckLanguageResult, QuestionWriteContext, QuestionDependencies>
    {
        public override Task PostConditions(CheckLanguageCmd cmd, ICheckLanguageResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ICheckLanguageResult> Work(CheckLanguageCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            return new ValidationSucceeded("Valid");
        }
    }
}