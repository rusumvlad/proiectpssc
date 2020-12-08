CREATE TABLE [base].[Question] (
    [QuestionId]   INT NOT NULL,
    [Title] NVARCHAR (255) NOT NULL,
    [Body]      NVARCHAR (255) NOT NULL,
    [TAGS]      NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([QuestionId] ASC),
);
