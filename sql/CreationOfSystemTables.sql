IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Category] (
    [Id] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Profiles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(50) NOT NULL,
    [Birthday] datetime2 NOT NULL,
    [BlockApartment] varchar(50) NOT NULL,
    [PhotoUrl] varchar(100) NOT NULL,
    CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Ocurrences] (
    [Id] uniqueidentifier NOT NULL,
    [PublishDateTime] datetime2 NOT NULL,
    [Content] varchar(600) NOT NULL,
    [ProfileId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Ocurrences] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Ocurrences_Profiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Warnings] (
    [Id] uniqueidentifier NOT NULL,
    [ProfileId] uniqueidentifier NOT NULL,
    [PublishDateTime] datetime2 NOT NULL,
    [Content] varchar(500) NOT NULL,
    CONSTRAINT [PK_Warnings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Warnings_Profiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Answers] (
    [Id] uniqueidentifier NOT NULL,
    [PublishDateTime] datetime2 NOT NULL,
    [Content] varchar(500) NOT NULL,
    [OcurrenceId] uniqueidentifier NOT NULL,
    [ProfileId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Ocurrences_OcurrenceId] FOREIGN KEY ([OcurrenceId]) REFERENCES [Ocurrences] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Answers_Profiles_ProfileId] FOREIGN KEY ([ProfileId]) REFERENCES [Profiles] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Answers_OcurrenceId] ON [Answers] ([OcurrenceId]);

GO

CREATE INDEX [IX_Answers_ProfileId] ON [Answers] ([ProfileId]);

GO

CREATE INDEX [IX_Ocurrences_ProfileId] ON [Ocurrences] ([ProfileId]);

GO

CREATE INDEX [IX_Warnings_ProfileId] ON [Warnings] ([ProfileId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190620214152_Inicial', N'2.2.4-servicing-10062');

GO

