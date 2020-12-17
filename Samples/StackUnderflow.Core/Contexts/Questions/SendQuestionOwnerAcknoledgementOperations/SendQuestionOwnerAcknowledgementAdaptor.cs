using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Access.Primitives.IO;
using GrainInterfaces;
using Orleans;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations.SendQuestionOwnerAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknoledgementOperations
{
    class SendQuestionOwnerAcknowledgementAdaptor : Adapter<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult, QuestionWriteContext, QuestionDependencies>
    {
        private readonly IClusterClient clusterClient;

        public SendQuestionOwnerAcknowledgementAdaptor(IClusterClient clusterClient)
        {
            this.clusterClient = clusterClient;
        }

        public override Task PostConditions(SendQuestionOwnerAcknowledgementCmd cmd, ISendQuestionOwnerAcknowledgementResult result, QuestionWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendQuestionOwnerAcknowledgementResult> Work(SendQuestionOwnerAcknowledgementCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var asyncHelloGrain = this.clusterClient.GetGrain<IAsyncHello>($"User{cmd.QuestionOwnerId}");
            await asyncHelloGrain.StartAsync();

            var stream = clusterClient.GetStreamProvider("SMSProvider").GetStream<string>(Guid.Empty, "email");
            await stream.OnNextAsync($"user{cmd.QuestionOwnerId}@email.com");

            return new AcknowledgementSent(1, 2);
        }
    }
}
