/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 13-03-2017
-- Description:	basins list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_basin]
AS
BEGIN
	SELECT [id_basin], [basin], [basin_abbr]
		FROM dbo.[basin];
END;
