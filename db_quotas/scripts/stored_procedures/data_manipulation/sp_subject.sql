/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 21-03-2017
-- Update date: 21-03-2017
-- Description:	subjects list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_subject]
AS
BEGIN
	SELECT	[id_subject],
            [subject],
            [subject_order],
            [id_subject_osm],
            [sorting]
		FROM dbo.[subject]
END;
