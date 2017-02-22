--ОБЩИЕ ОБЪЁМЫ КВОТ НА ВЫЛОВ ВБР
CREATE TABLE [dbo].[limits_common]
(
	[id_basin] INT NOT NULL,
	[date] DATETIME NOT NULL,
	[id_regime] INT NOT NULL,
	[id_region] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_subject] INT NOT NULL,
	[id_unit] INT NOT NULL, 
    [document] NVARCHAR(50) NOT NULL, 
    [document_date] DATETIME NOT NULL, 
    [catch_volume] DECIMAL(38,17) NULL, 
    [person] NVARCHAR(50) NULL,
    [responsible] NVARCHAR(64) NULL, 
    [timestamp_] DATETIME NULL, 
    CONSTRAINT [PK_limits_common] PRIMARY KEY ([id_basin], [date], [id_regime], [id_region], [id_fish], [id_subject], [id_unit], [document], [document_date])
)
