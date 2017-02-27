--ИЕРАРХИЯ СУБЪЕКТОВ РФ
CREATE TABLE [dbo].[subject_p]
(
	[id_subject] INT NOT NULL,
	[id_subject_parent] INT NOT NULL, 
    CONSTRAINT [PK_subject_p] PRIMARY KEY ([id_subject], [id_subject_parent])
)
