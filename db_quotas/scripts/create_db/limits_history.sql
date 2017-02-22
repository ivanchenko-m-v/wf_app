--ИЗМЕНЕНИЯ ОДУ, ОБЩИХ КВОТ И КВОТ ПОЛЬЗОВАТЕЛЕЙ НА ВЫЛОВ ВБР
CREATE TABLE [dbo].[limits_history]
(
	[id] INT NOT NULL PRIMARY KEY,
	[id_limits_kind] INT NOT NULL,
	[sign] INT NOT NULL,
	[distribution] NVARCHAR(150) NULL,
	[id_declarant] INT NOT NULL,
	[id_basin] INT NOT NULL,
	[date] DATETIME NOT NULL,
	[id_regime] INT NOT NULL,
	[id_region] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_subject] INT NOT NULL,
	[id_unit] INT NOT NULL, 
    [catch_volume] DECIMAL(38,17) NULL, 
    [document] NVARCHAR(50) NULL, 
    [document_date] DATETIME NULL, 
    [document_change] NVARCHAR(50) NULL,
    [document_change_date] DATETIME NULL, 
    [person] NVARCHAR(50) NULL,
    [note] NVARCHAR(255) NULL,
    [responsible] NVARCHAR(64) NULL, 
    [timestamp_] DATETIME NULL
)