SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
USE limits_2009c
GO
*/
/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 16-02-2017
-- Update date: 23-03-2017
-- Description:	fish catch for 2 years 
-- with catching percent less than @nPercent
-- @StatType defines type of accounting, must be 'o', 's' or 'so'
-- ============================================================================
*/
CREATE PROCEDURE sp_fishing_2years_v3
(
	-- Add the parameters for the stored procedure here
	@nYear1 int, 
	@nYear2 int, 
	@nPercent int,
	@StatType NVARCHAR(2),
	@id_subject int = 0,
	@id_regime int = 0,
	@id_region int = 0,
	@id_WBR int = 0,
	@id_declarant int = 0
)
AS
BEGIN
	--
	IF 'S'=UPPER(@StatType)
	BEGIN
		SELECT * 
		FROM [dbo].[fn_fishing_2years_S](
											@nYear1, 
											@nYear2, 
											@nPercent,
											@id_subject,
											@id_regime,
											@id_region,
											@id_WBR,
											@id_declarant
										);
		RETURN;
	END;
	--
	IF 'O'=UPPER(@StatType)
	BEGIN
		SELECT * 
		FROM [dbo].[fn_fishing_2years_O](
											@nYear1, 
											@nYear2, 
											@nPercent,
											@id_subject,
											@id_regime,
											@id_region,
											@id_WBR,
											@id_declarant
										);
		RETURN;
	END;
	--
	IF 'SO'=UPPER(@StatType)
	BEGIN
		SELECT * 
		FROM [dbo].[fn_fishing_2years_SO](
											@nYear1, 
											@nYear2, 
											@nPercent,
											@id_subject,
											@id_regime,
											@id_region,
											@id_WBR,
											@id_declarant
										 );		
		RETURN;
	END;
	--
END
GO
