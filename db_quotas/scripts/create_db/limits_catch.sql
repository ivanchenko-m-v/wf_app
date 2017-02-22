--ОСВОЕНИЕ ПОЛЬЗОВАТЕЛЯМИ КВОТ НА ВЫЛОВ ВБР
CREATE TABLE [dbo].[limits_catch]
(
	[date] DATETIME NOT NULL,
	[id_basin] INT NOT NULL,
	[id_subject] INT NOT NULL,
	[id_declarant] INT NOT NULL,
	[id_regime] INT NOT NULL,
	[id_region] INT NOT NULL,
	[id_fish] INT NOT NULL,
	[id_unit] INT NOT NULL, 
 	[portion_sign] INT NOT NULL, 
    [portion] DECIMAL(38,17) NULL, 
    [limits_volume] DECIMAL(38,17) NULL, 
    [catch_volume_stat] DECIMAL(38,17) NULL, 
    [catch_volume_stat_oper] DECIMAL(38,17) NULL, 
    [catch_volume_1] DECIMAL(38,17) NULL, 
    [catch_volume_2] DECIMAL(38,17) NULL, 
    [catch_volume_oper] DECIMAL(38,17) NULL, 
    CONSTRAINT [PK_limits_catch] PRIMARY KEY ([date], [id_basin], [id_subject], [id_declarant], [id_regime], [id_region], [id_fish], [id_unit], [portion_sign])
)
