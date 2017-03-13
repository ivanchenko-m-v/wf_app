/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 13-03-2017
-- Update date: 13-03-2017
-- Description:	regimes list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_regime]
AS
BEGIN
	SELECT [id_regime], [regime], [mode], [regime_order]
		FROM dbo.[regime];
END;