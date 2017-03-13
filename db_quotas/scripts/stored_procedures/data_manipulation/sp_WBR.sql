/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 13-03-2017
-- Description:	WBRs list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_WBR]
AS
BEGIN
	SELECT	[id_fish], [fish], [note], 
			[id_fish_osm], [fish_order], [sorting]
		FROM dbo.[fish]
END;
