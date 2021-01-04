using CSharp.Choices;

namespace StackUnderflow.Domain.Schema.Questions.CreateQuestionOp
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }


        public class QuestionCreated : ICreateQuestionResult
        {
            public int QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Body { get; private set; }
            public string Tags { get; private set; }

            public QuestionCreated(int questionId, string title, string body, string tags)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
            }

            
        }
        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; }

            public QuestionNotCreated(string reason)
            {
                Reason = reason;
            }
        }
    }
}
