--СУБЪЕКТЫ РФ В СОСТАВЕ РЫБОПРОМЫСЛОВЫХ БАССЕЙНОВ
CREATE TABLE [dbo].[subject]
(
	[id_subject]	INT NOT NULL PRIMARY KEY,
	[subject]	NVARCHAR(50),
	[subject_order]	NVARCHAR(50),
	[id_subject_osm]	INT,
	[responsible]	NVARCHAR(30),
	[timestamp_]	DATETIME,
	[sorting]	INT
)
