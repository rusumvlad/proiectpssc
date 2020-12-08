CREATE TABLE [base].[Reply] (
    [ReplyId]   INT NOT NULL,
    [QuestionId] INT NOT NULL,
    [AuthorUserId]      INT NOT NULL,
    [Body]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Reply] PRIMARY KEY CLUSTERED ([ReplyId] ASC),
    CONSTRAINT [FK_Reply] FOREIGN KEY ([QuestionId]) REFERENCES [base].[Question] ([QuestionId]),
);