IF NOT EXISTS (SELECT 1 FROM sysobjects WHERE name='CandidateHealthInsuranceRegistration' and xtype='U')
BEGIN
    CREATE TABLE [acc].[CandidateHealthInsuranceRegistration]
    (
        [Id] INT IDENTITY(1, 1),
        [CandidateId] INT NOT NULL,
        [HealthInsuranceName] NVARCHAR(MAX),
        [HealthInsuranceNumber] NVARCHAR(MAX),
        [RegistationStatusId] INT NOT NULL,
        [ReasonOfEndingId] INT NULL,
        [StartDate] DATETIME2 NOT NULL,
        [EndDate] DATETIME2 NULL,
        [UpdatedByUser] NVARCHAR(MAX) NOT NULL,
        [DateTimeUtc] DATETIME2 NOT NULL

        CONSTRAINT [PK_CandidateHealthInsuranceRegistration] PRIMARY KEY CLUSTERED ([Id]),
        CONSTRAINT [FK_CandidateHealthInsuranceRegistration_Candidate] FOREIGN KEY ([CandidateId]) REFERENCES [acc].[Candidate] ([Id])
    );
END
GO
