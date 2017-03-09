/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 09-03-2017
-- Update date: 09-03-2017
-- Description:	one portion chaining transfer through declarants
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_one_portion_history]
(
	@id_portion int
)
AS
BEGIN
	WITH portion_children( 
							id_portion_actual, 
							id_portion, 
							id_portion_was,
							id_basin, 
							id_regime,
							id_fish, 
							id_region,
							portion, 
							date_open, 
							date_close,
							report_number, 
							report_date, 
							id_declarant_history,
							contract_number, 
							contract_date
						 )
	AS
	(
		SELECT	B.[id_history] AS [id_portion_actual],
				B.[id_history] AS [id_portion],
				B.[id_history_was] AS [id_portion_was],
				B.[id_basin], 
				B.[id_regime],
				B.[id_fish], 
				B.[id_region],
				B.[portion], 
				CONVERT(NVARCHAR(10), B.[date_open], 102) AS date_open, 
				CONVERT(NVARCHAR(10), B.[date_close], 102) AS date_close,
				B.[report_number], 
				CONVERT(NVARCHAR(10), B.[report_date], 102) AS report_date, 
				B.[id_declarant_history],
				ISNULL(B.[contract_number],'') AS contract_number, 
				ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 102),'') AS contract_date
			FROM [dbo].[portion_history] B
			WHERE (B.[id_history]=[dbo].fn_portion_actual(@id_portion))
		UNION ALL
			SELECT	A.[id_portion_actual] AS [id_portion_actual],
					B.[id_history] AS [id_portion],
					B.[id_history_was] AS [id_portion_was],
					B.[id_basin], 
					B.[id_regime],
					B.[id_fish], 
					B.[id_region],
					B.[portion],
					CONVERT(NVARCHAR(10), B.[date_open], 102) AS date_open, 
					CONVERT(NVARCHAR(10), B.[date_close], 102) AS date_close,
					B.[report_number], 
					CONVERT(NVARCHAR(10), B.[report_date], 102) AS report_date, 
					B.[id_declarant_history],
					ISNULL(B.[contract_number],'') AS contract_number, 
					ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 102),'') AS contract_date
			FROM [dbo].[portion_history] B
				JOIN portion_children A ON A.[id_portion_was]=B.[id_history]
	)
	SELECT  FA.id_portion_actual 
		   ,BAS.[basin], RG.[regime]
		   ,FSH.[fish], RN.[region]
		   ,FA.[portion], FA.[date_open], FA.[date_close]
		   ,FA.[report_number], FA.[report_date]
		   ,DCL.[declarant], DCL.[inn]
		   ,FA.[contract_number], FA.[contract_date]
	FROM 
		( --dbo.[declarant] DCL
		( --dbo.[region] RN
		( --dbo.[fish] FSH
		( --dbo.[regime] RG
		(portion_children FA INNER JOIN dbo.[basin] BAS ON FA.[id_basin]=BAS.[id_basin])
		INNER JOIN dbo.[regime] RG ON FA.[id_regime]=RG.[id_regime])
		INNER JOIN dbo.[fish] FSH ON FA.[id_fish]=FSH.[id_fish])
		INNER JOIN dbo.[region] RN ON FA.[id_region]=RN.[id_region])
		INNER JOIN dbo.[declarant_history] DCL ON FA.[id_declarant_history]=DCL.[id_declarant_history])
	WHERE (FA.[report_date] IS NOT NULL)
	GROUP BY id_portion_actual, basin, regime, fish, region,
		     portion, date_open, date_close, report_number, report_date,
		     declarant, inn, contract_number, contract_date
	ORDER BY id_portion_actual, date_open;
END
GO
