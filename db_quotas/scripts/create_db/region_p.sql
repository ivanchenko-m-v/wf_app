--ИЕРАРХИЯ ЗОН ПРОМЫСЛА ()
CREATE TABLE [dbo].[region_p]
(
	[id_region] INT NOT NULL,
	[id_region_parent] INT NOT NULL, 
    CONSTRAINT [PK_region_p] PRIMARY KEY ([id_region], [id_region_parent])
)
