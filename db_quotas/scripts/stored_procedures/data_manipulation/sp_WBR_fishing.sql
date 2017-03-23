/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 23-03-2017
-- Description:	WBRs list, which contains in limits_catch table
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_WBR_fishing]
AS
BEGIN
	SELECT	[id_fish], [fish], [note], 
			[id_fish_osm], [fish_order], [sorting]
		FROM dbo.[fish]
		WHERE [id_fish] IN(SELECT [id_fish] FROM [dbo].[limits_catch])
		ORDER BY [id_fish];
END;
