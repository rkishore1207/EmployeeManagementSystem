CREATE TABLE [data].[Email] (
    [UID]           UNIQUEIDENTIFIER NOT NULL,
    [UserUID]       UNIQUEIDENTIFIER NOT NULL,
    [ReceiverEmail] VARCHAR (500)    NOT NULL,
    [Subject]       VARCHAR (500)    NULL,
    [EmailContent]  VARCHAR (MAX)    NULL,
    [CreatedOn]     DATETIME         NULL,
    CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED ([UID] ASC),
    CONSTRAINT [FK_User_Email] FOREIGN KEY ([UserUID]) REFERENCES [data].[User] ([UID])
);

