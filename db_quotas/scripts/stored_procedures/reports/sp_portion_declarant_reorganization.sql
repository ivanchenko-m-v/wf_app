/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 02-03-2017
-- Update date: 02-03-2017
-- Description:	declarant portions with declarant reorganizations 
-- ============================================================================
*/
CREATE PROCEDURE [dbo].[sp_portion_declarant_reorganization]
	--@param1 int = 0,
	--@param2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT P.id_basin, 
		   B.basin, 
		   P.id_regime, 
		   R.regime, 
		   P.id_fish, 
		   F.fish, 
		   P.id_region, 
		   RG.region, 
		   CONVERT(REAL, P.portion) AS portion, 
		   CONVERT(NVARCHAR(16), P.date_open, 104) AS date_open, 
		   CONVERT(NVARCHAR(16), P.date_close, 104) AS date_close, 
		   P.report_number, CONVERT(NVARCHAR(16), P.report_date, 104) AS report_date, 
		   D.id_declarant, 
		   D.id_declarant_history, 
		   D.id_declarant_history_was, 
		   D.declarant, 
		   D.inn, 
		   ISNULL(P.contract_number,'') AS contract_number, 
		   ISNULL(CONVERT(NVARCHAR(16), P.contract_date, 104),'') AS contract_date, 
		   ISNULL(P.transfer_reason, '') AS transfer_reason
		FROM 
			(((((
			[limits_2009c].[dbo].[portion] AS P INNER JOIN [limits_2009c].[dbo].[declarant_history] AS D ON P.id_declarant_history=D.id_declarant_history)
				INNER JOIN [limits_2009c].[dbo].[regime] AS R ON P.id_regime=R.id_regime)
				INNER JOIN  [limits_2009c].[dbo].[fish] AS F ON P.id_fish=F.id_fish)
				INNER JOIN [limits_2009c].[dbo].[region] AS RG ON P.id_region=RG.id_region)
				INNER JOIN [limits_2009c].[dbo].[basin] AS B ON P.id_basin=B.id_basin)
		ORDER BY D.id_declarant_history, D.id_declarant_history_was, P.id_basin, P.id_regime, P.id_region, P.id_fish;

END
GO

/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 02-03-2017
-- Update date: 02-03-2017
-- Description:	declarant portions_history with declarant reorganizations 
-- ============================================================================
*/
CREATE PROCEDURE [dbo].[sp_portion_history_declarant_reorganization]
	--@param1 int = 0,
	--@param2 int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT P.id_basin, 
		   B.basin, 
		   P.id_regime, 
		   R.regime, 
		   P.id_fish, 
		   F.fish, 
		   P.id_region, 
		   RG.region, 
		   CONVERT(REAL, P.portion) AS portion, 
		   CONVERT(NVARCHAR(16), P.date_open, 104) AS date_open, 
		   CONVERT(NVARCHAR(16), P.date_close, 104) AS date_close, 
		   P.report_number, CONVERT(NVARCHAR(16), P.report_date, 104) AS report_date, 
		   D.id_declarant, 
		   D.id_declarant_history, 
		   D.id_declarant_history_was, 
		   D.declarant, 
		   D.inn, 
		   ISNULL(P.contract_number,'') AS contract_number, 
		   ISNULL(CONVERT(NVARCHAR(16), P.contract_date, 104),'') AS contract_date, 
		   ISNULL(P.transfer_reason, '') AS transfer_reason,
		   ISNULL(S.[sign], '') AS id_sign,
		   ISNULL(S.[sign_name], '') AS sign_name
		FROM 
			(((((
			[limits_2009c].[dbo].[portion_history] AS P INNER JOIN [limits_2009c].[dbo].[declarant_history] AS D ON P.id_declarant_history=D.id_declarant_history)
				INNER JOIN [limits_2009c].[dbo].[regime] AS R ON P.id_regime=R.id_regime)
				INNER JOIN  [limits_2009c].[dbo].[fish] AS F ON P.id_fish=F.id_fish)
				INNER JOIN [limits_2009c].[dbo].[region] AS RG ON P.id_region=RG.id_region)
				INNER JOIN [limits_2009c].[dbo].[basin] AS B ON P.id_basin=B.id_basin)
				LEFT OUTER JOIN [limits_2009c].[dbo].[sign] AS S ON P.[sign]=S.[sign]
		ORDER BY D.id_declarant_history, D.id_declarant_history_was, P.id_basin, P.id_regime, P.id_region, P.id_fish;
END
GO