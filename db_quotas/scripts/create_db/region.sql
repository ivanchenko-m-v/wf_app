--ПРОМЫСЛОВЫЕ РАЙОНЫ (ЗОНЫ ПРОМЫСЛА)
CREATE TABLE [dbo].[region]
(
	[id_region] INT NOT NULL PRIMARY KEY,
	[region] NVARCHAR(255),
	[note] NVARCHAR(250),
	[responsible] NVARCHAR(30),
	[timestamp_] SMALLDATETIME,
	[region_order] NVARCHAR(150),
	[id_region_osm] INT,
	[sorting] INT NOT NULL
)
