--КЛАССИФИКАТОР ВАРИАНТОВ РАСПРЕДЕЛЕНИЯ КВОТ ПОЛЬЗОВАТЕЛЕЙ ВБР
CREATE TABLE [dbo].[distribution_lim]
(
	[id_distribution_lim] INT NOT NULL PRIMARY KEY,
	[distribution_lim] NVARCHAR(256) NULL,
	[creation_date] DATETIME NULL
)
