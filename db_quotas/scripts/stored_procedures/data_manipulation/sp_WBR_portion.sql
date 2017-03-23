/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 22-03-2017
-- Description:	WBRs list, which portions was distributed 
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_WBR_portion]
AS
BEGIN
	SELECT	[id_fish], [fish], [note], 
			[id_fish_osm], [fish_order], [sorting]
		FROM dbo.[fish]
		WHERE [id_fish] IN(SELECT [id_fish] FROM [dbo].[portion])
		ORDER BY [id_fish];
END;
