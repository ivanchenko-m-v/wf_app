﻿--ПЕРЕДАЧА ДОЛЕЙ И КВОТ ПОЛЬЗОВАТЕЛЕЙ ВБР
CREATE TABLE [dbo].[portion_limits_transfer]
(
	[id_index] INT NOT NULL PRIMARY KEY,
	[id_history] INT NOT NULL,
	[portion_limit_flag] TINYINT NOT NULL,
	[id_declarant_from] INT NOT NULL,
	[id_declarant_to] INT NOT NULL,
	[id_basin] INT NOT NULL,
	[id_regime] INT NOT NULL,
	[id_region] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_subject_from] INT NOT NULL,
	[id_subject] INT NOT NULL,
	[id_unit] INT NOT NULL,
	[portion_limit]	DECIMAL(38, 17),
	[date] DATETIME,
	[document] NVARCHAR(50),
	[document_date] DATETIME,
	[transfer_number] NVARCHAR(60),
	[transfer_date] DATETIME,
	[transfer_reason] NVARCHAR(150),
	[declarant_from] NVARCHAR(250),
	[declarant_from_inn] NVARCHAR(20),
	[declarant_to] NVARCHAR(250),
	[declarant_to_inn] NVARCHAR(20),
	[id_history_from] INT,
	[id_history_to] INT,
	[report_organization] NVARCHAR(150),
	[report_number] NVARCHAR(60),
	[report_date] DATETIME,
	[report_document] NVARCHAR(50),
	[contract_organization] NVARCHAR(150),
	[contract_number] NVARCHAR(60),
	[contract_date] DATETIME,
	[note] NVARCHAR(255),
	[responsible] NVARCHAR(30),
	[timestamp_]	DATETIME
)
