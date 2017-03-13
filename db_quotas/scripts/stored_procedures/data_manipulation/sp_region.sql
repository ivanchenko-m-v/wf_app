/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 13-03-2017
-- Description:	regions list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_region]
AS
BEGIN
	SELECT	[id_region], [region], [note], 
			[id_region_osm], [region_order], [sorting]
		FROM dbo.[region]
END;
