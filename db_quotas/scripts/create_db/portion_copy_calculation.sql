--ОБЪЕКТ И ЗОНА ПРОМЫСЛА ДЛЯ КОПИРОВАНИЯ ДОЛЕЙ ПРИ РАСЧЁТАХ
CREATE TABLE [dbo].[portion_copy_calculation]
(
	[id_regime] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_region] INT NOT NULL,
	[regime] NVARCHAR(55) NOT NULL,
	[fish] NVARCHAR(45) NOT NULL,
	[region] NVARCHAR(255) NOT NULL,
	[id_fish_copy] INT NOT NULL,
	[id_region_copy] INT NOT NULL,
	[fish_copy] NVARCHAR(45) NOT NULL,
	[region_copy] NVARCHAR(255) NOT NULL,
	[id_basin] INT NOT NULL
)
