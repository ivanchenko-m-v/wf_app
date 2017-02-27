--РЕЖИМЫ (ВИДЫ) ПРОМЫСЛА (НАПРАВЛЕНИЯ ИСПОЛЬЗОВАНИЯ КВОТ)
CREATE TABLE [dbo].[regime]
(
	[id_regime] INT NOT NULL PRIMARY KEY,
	[regime] NVARCHAR(55) NULL,
	[mode] INT NULL,
	[regime_order] NVARCHAR(55) NULL
)
