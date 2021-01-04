using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp.SendReplyAuthorAcknowledgementResult;

namespace StackUnderflow.Domain.Adapters.Questions.SendReplyAuthorAcknowledgementOp
{
    class SendReplyAuthorAcknowledgementAdaptor : Adapter<SendReplyAuthorAcknowledgementCmd, ISendReplyAuthorAcknowledgementResult, QuestionWriteContext, QuestionDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendReplyAuthorAcknowledgementAdaptor(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }
        public override Task PostConditions(SendReplyAuthorAcknowledgementCmd cmd, ISendReplyAuthorAcknowledgementResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendReplyAuthorAcknowledgementResult> Work(SendReplyAuthorAcknowledgementCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var helloGrain = this.clusterClient.GetGrain<IHello>(0);

            var helloResult = await helloGrain.SayHello("My hello greeting");

            return new AcknowledgementSent(1, 2);
        }
    }
}