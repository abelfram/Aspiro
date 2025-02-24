CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (50)  NOT NULL,
    [Surname]   VARCHAR (20)  CONSTRAINT [df_dni] DEFAULT ('Franco') NOT NULL,
    [Dni]       VARCHAR (10)  NOT NULL,
    [Email]     VARCHAR (255) CONSTRAINT [df_email] DEFAULT ('sinemail@ejemplo.com') NOT NULL,
    [BirthDate] DATE          CONSTRAINT [df_birthDate] DEFAULT ('2000-01-01') NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

