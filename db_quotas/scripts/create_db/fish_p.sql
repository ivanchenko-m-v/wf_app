--иерархия ВБР 
CREATE TABLE [dbo].[fish_p]
(
	[id_fish] INT NOT NULL,
	[id_fish_parent] INT NOT NULL, 
    CONSTRAINT [PK_fish_p] PRIMARY KEY ([id_fish], [id_fish_parent])
)
