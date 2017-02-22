--ВБР
CREATE TABLE [dbo].[fish]
(
	[id_fish] INT NOT NULL PRIMARY KEY, 
    [fish] NVARCHAR(255) NULL, 
    [note] NVARCHAR(255) NULL, 
    [responsible] NVARCHAR(64) NULL, 
    [timestamp_] DATETIME NULL, 
    [id_fish_osm] INT NULL, 
    [fish_order_title] NVARCHAR(255) NULL, 
    [sorting] INT NULL 
)
