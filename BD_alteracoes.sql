CREATE TABLE [dbo].[LocalizacaoDor] (
    [IdTratamentoMaosPes] INT            NOT NULL,
    [IdPaciente]          INT            NOT NULL,
    [data]                DATE           NOT NULL,
    [localizacao]         NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_LocalizacaoDor] PRIMARY KEY CLUSTERED ([IdTratamentoMaosPes] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDor_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente]),
    CONSTRAINT [FK_LocalizacaoDor_TratamentoMaosPes] FOREIGN KEY ([IdTratamentoMaosPes]) REFERENCES [dbo].[TratamentoMaosPes] ([IdTratamentoMaosPes])
);

CREATE TABLE [dbo].[LocalizacaoDorConsulta] (
    [IdLocalizacaoDor] INT            IDENTITY (1, 1) NOT NULL,
    [IdPaciente]       INT            NOT NULL,
    [data]             DATE           NOT NULL,
    [localizacao]      NVARCHAR (MAX) NOT NULL,
    [observacoes] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_LocalizacaoDorConsulta] PRIMARY KEY CLUSTERED ([IdLocalizacaoDor] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDorConsulta_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
);

CREATE TABLE [dbo].[LocalizacaoDorDopplerArterialVenoso] (
    [IdTratamento] INT        IDENTITY (1, 1) NOT NULL,
    [IdPaciente]   INT        NOT NULL,
    [data]         DATE       NOT NULL,
    [localizacao]  NVARCHAR(MAX) NULL,
    CONSTRAINT [PK_LocalizacaoDorDopplerArterialVenoso] PRIMARY KEY CLUSTERED ([IdTratamento] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDorDopplerArterialVenoso_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
);

CREATE TABLE [dbo].[LocalizacaoDorVacinacao] (
    [IdTratamento] INT            IDENTITY (1, 1) NOT NULL,
    [IdPaciente]   INT            NOT NULL,
    [data]         DATE           NOT NULL,
    [localizacao]  NVARCHAR (MAX) NOT NULL,
    [observacoes]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LocalizacaoDorVacinacao] PRIMARY KEY CLUSTERED ([IdTratamento] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDorVacinacao_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
);


CREATE TABLE [dbo].[LocalizacaoDorEspirometria] (
    [IdTratamento] INT            IDENTITY (1, 1) NOT NULL,
    [IdPaciente]   INT            NOT NULL,
    [data]         DATE           NOT NULL,
    [localizacao]  NVARCHAR (MAX) NOT NULL,
    [observacoes]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LocalizacaoDorEspirometria] PRIMARY KEY CLUSTERED ([IdTratamento] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDorEspirometria_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
);

CREATE TABLE [dbo].[LocalizacaoDorDopplerFetal]
(
	[IdTratamento] INT            IDENTITY (1, 1) NOT NULL,
    [IdPaciente]   INT            NOT NULL,
    [data]         DATE           NOT NULL,
    [localizacao]  NVARCHAR (MAX) NOT NULL,
    [observacoes]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LocalizacaoDorDopplerFetal] PRIMARY KEY CLUSTERED ([IdTratamento] ASC, [IdPaciente] ASC, [data] ASC),
    CONSTRAINT [FK_LocalizacaoDorDopplerFetal_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
)

//alterei --> tirei o campo localizacaoDor
CREATE TABLE [dbo].[Consulta] (
    [IdConsulta]         INT            IDENTITY (1, 1) NOT NULL,
    [dataConsulta]       DATE           NOT NULL,
    [horaInicioConsulta] VARCHAR (50)   NOT NULL,
    [historiaAtual]      NVARCHAR (MAX) NULL,
    [sintomatologia]     NVARCHAR (MAX) NULL,
    [sinais]             NVARCHAR (MAX) NULL,
    [escalaDor]          VARCHAR (50)   NULL,
    [idPaciente]         INT            NOT NULL,
    [idEnfermeiro]       INT            NOT NULL,
    [valorConsulta]      DECIMAL (6, 2) NULL,
    [horaFimConsulta]    NVARCHAR (50)  NOT NULL,
    [diagnostico]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED ([IdConsulta] ASC),
    CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY ([idPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente]),
    CONSTRAINT [FK_Consulta_Enfermeiro] FOREIGN KEY ([idEnfermeiro]) REFERENCES [dbo].[Enfermeiro] ([IdEnfermeiro])
);

//alterei (quantidade string para permitir, exemplo: "meio comprimido", ou "1/4", ou "1/2"
CREATE TABLE [dbo].[Medicacao] (
    [IdMedicacao]   INT            IDENTITY (1, 1) NOT NULL,
    [medicamentos]  NVARCHAR (MAX) NOT NULL,
    [jejum]         NVARCHAR (50)  NULL,
    [pequenoAlmoco] NVARCHAR (50)  NULL,
    [almoco]        NVARCHAR (50)  NULL,
    [lanche]        NVARCHAR (50)  NULL,
    [jantar]        NVARCHAR (50)  NULL,
    [deitar]        NVARCHAR (50)  NULL,
    [IdPaciente]    INT            NULL,
    [data]          DATE           NOT NULL,
    [quantidadeJejum] NVARCHAR(500) NULL, 
    [quantidadePequenoAlmoco] NVARCHAR(500) NULL, 
    [quantidadeAlmoco] NVARCHAR(500) NULL, 
    [quantidadeLanche] NVARCHAR(500) NULL, 
    [quantidadeJantar] NVARCHAR(500) NULL, 
    [quantidadeDeitar] NVARCHAR(500) NULL, 
    [observacoes] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Medicacao] PRIMARY KEY CLUSTERED ([IdMedicacao] ASC),
    CONSTRAINT [FK_Medicacao_Paciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Paciente] ([IdPaciente])
);
