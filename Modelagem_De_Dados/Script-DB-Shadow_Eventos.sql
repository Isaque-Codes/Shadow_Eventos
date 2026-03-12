CREATE DATABASE Shadow_Eventos
GO

USE Shadow_Eventos
GO

-- DDL

CREATE TABLE Palestrante (
	PalestranteID INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR (75) NOT NULL,
	AreaAtuacao NVARCHAR (50) NOT NULL
);
GO

CREATE TABLE Evento (
	EventoID INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR (75) NOT NULL,
	DataEvento DATETIME2 (0) NOT NULL,
	LocalEvento NVARCHAR (150) NOT NULL,

	PalestranteID INT FOREIGN KEY REFERENCES Palestrante(PalestranteID)
);
GO

CREATE TABLE Participante (
	ParticipanteID INT PRIMARY KEY IDENTITY,
	Nome NVARCHAR (75) NOT NULL,
	Email NVARCHAR (125) UNIQUE NOT NULL
);
GO

CREATE Table Inscricao (
	InscricaoID INT PRIMARY KEY IDENTITY,

	EventoID INT FOREIGN KEY REFERENCES Evento (EventoID),
	ParticipanteID INT FOREIGN KEY REFERENCES Participante(ParticipanteID)

	CONSTRAINT Inscricao_Evento_Participante UNIQUE (EventoID, ParticipanteID)
);
GO