--ОДУ
CREATE TABLE [dbo].[limits_base]
(
	[id_basin] INT NOT NULL,
	[date] DATETIME NOT NULL,
	[id_region] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_unit] INT NOT NULL, 
    [document] NVARCHAR(50) NOT NULL, 
    [document_date] DATETIME NOT NULL, 
    [catch_volume] DECIMAL(38,17) NULL, 
    [person] NVARCHAR(50) NULL,
    [responsible] NVARCHAR(64) NULL, 
    [timestamp_] DATETIME NULL, 
    CONSTRAINT [PK_limits_base] PRIMARY KEY ([id_basin], [date], [id_region], [id_fish], [id_unit], [document], [document_date])
)
