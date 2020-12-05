﻿using System;
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
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;

namespace StackUnderflow.API.AspNetCore.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly DatabaseContext _dbContext;

        public QuestionsController(IInterpreterAsync interpreter, DatabaseContext dbContext)
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

            var expr = from createTenantResult in QuestionContext.CreateQuestion(cmd)
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            await _dbContext.SaveChangesAsync();

            _dbContext.Questions.Add(new DatabaseModel.Models.Question { QuestionId = cmd.QuestionId, Title = cmd.Title, Body = cmd.Body, Tags = cmd.Tags });
            await _dbContext.SaveChangesAsync();
            var reply = await _dbContext.Questions.Where(r => r.QuestionId == cmd.QuestionId).SingleOrDefaultAsync();
            _dbContext.Questions.Update(reply);

            return r.Match(
                succ => (IActionResult)Ok("Succeeded"),
                fail => BadRequest("Question could not be added")
                );
        }
    }
}
