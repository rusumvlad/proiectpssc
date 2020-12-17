using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using LanguageExt;
using Microsoft.AspNetCore.Http;
using StackUnderflow.Domain.Core.Contexts.Questions.CreateQuestionOp;
using StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknoledgementOperations;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using StackUnderflow.Domain.Schema.Questions.SendReplyAuthorAcknowledgementOp;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknoledgementOperations;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Questions.CheckLanguageOp;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public QuestionsController(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd cmd)
        {
            var dep = new QuestionDependencies();

            var questions = await _dbContext.Questions.ToListAsync();

            var ctx = new QuestionWriteContext(questions);
            _dbContext.Questions.AttachRange(questions);

            var expr = from createTenantResult in QuestionContext.CreateQuestion(cmd)
                       from checkLanguageResult in QuestionContext.CheckLanguage(new CheckLanguageCmd(cmd.Body))
                       from sendAckAuthor in QuestionContext.SendQuestionOwnerAcknowledgment(new SendQuestionOwnerAcknowledgementCmd(1, 2))
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            await _dbContext.SaveChangesAsync();

            _dbContext.Questions.Add(new Question { QuestionId = cmd.QuestionId, Title = cmd.Title, Body = cmd.Body, Tags = cmd.Tags });
            await _dbContext.SaveChangesAsync();

            return r.Match(
                succ => (IActionResult)Ok("Question was added!"),
                fail => BadRequest("Question could not be added")
                );
        }

        [HttpPost("reply")]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyCmd cmd)
        {
            var dep = new QuestionDependencies();

            var replies = await _dbContext.Replies.ToListAsync();
            // var ctx = new QuestionWriteContext(replies);

            _dbContext.Replies.AttachRange(replies);
            var ctx = new QuestionWriteContext(new EFList<Reply>(_dbContext.Replies));
            var expr = from createTenantResult in QuestionContext.CreateReply(cmd)
                       from checkLanguageResult in QuestionContext.CheckLanguage(new CheckLanguageCmd(cmd.Body))
                       from sendAckAuthor in QuestionContext.SendReplyAuthorAcknowledgement(new SendReplyAuthorAcknowledgementCmd(Guid.NewGuid(), 1, 2))
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            _dbContext.Replies.Add(new Reply { ReplyId = cmd.ReplyId, QuestionId = cmd.QuestionId, AuthorUserId = cmd.AuthorUserId,   Body = cmd.Body  });
            var reply = await _dbContext.Replies.Where(r => r.ReplyId == cmd.ReplyId).SingleOrDefaultAsync();
            await _dbContext.SaveChangesAsync();

            return r.Match(
                succ => (IActionResult)Ok("Reply was added!"),
                fail => BadRequest("Reply could not be added")
                );
        }
    }
}
