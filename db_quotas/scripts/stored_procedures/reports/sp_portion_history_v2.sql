/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 06-03-2017
-- Update date: 03-04-2017
-- Update date: 13-07-2017 - v2, v3 
-- Description:	portions chaining transfer through declarants
--				03-04-2016
--				убрано условие WHERE (FA.[report_date] IS NOT NULL)
--              13-07-2017  
--              - v2 - вариант без учёта записей с sign=6(Изменение доли)
-- ============================================================================
*/
/*
USE limits_2009c
GO
*/
/**
 *
 *  sp_portion_history_v2 - работает наиболее быстро и правильно
 *
 */
CREATE PROCEDURE [dbo].[sp_portion_history_v2]
	@id_basin INT = 0,
	@id_regime INT = 0,
	@id_fish INT = 0,
	@id_region INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--service variables
	DECLARE @id_bas_from INT, @id_bas_to INT;
	DECLARE @id_rgm_from INT, @id_rgm_to INT;
	DECLARE @id_fs_from INT, @id_fs_to INT;
	DECLARE @id_rgn_from INT, @id_rgn_to INT;
	--
	--@id_basin
	SET @id_bas_from = @id_basin;
	IF @id_basin <> 0  
		SET @id_bas_to = @id_basin;
	ELSE 
		SET @id_bas_to = 0x7FFFFFFF; --max int value
	--@id_regime
	SET @id_rgm_from = @id_regime;
	IF @id_regime <> 0  
		SET @id_rgm_to = @id_regime;
	ELSE 
		SET @id_rgm_to = 0x7FFFFFFF; --max int value
	--@id_fish
	SET @id_fs_from = @id_fish;
	IF @id_fish <> 0  
		SET @id_fs_to = @id_fish;
	ELSE 
		SET @id_fs_to = 0x7FFFFFFF; --max int value
	--@id_region
	SET @id_rgn_from = @id_region;
	IF @id_region <> 0  
		SET @id_rgn_to = @id_region;
	ELSE 
		SET @id_rgn_to = 0x7FFFFFFF; --max int value

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
							contract_date,
							op_sign
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
				ISNULL(CONVERT(NVARCHAR(10), B.[report_date], 102),'') AS report_date,
				B.[id_declarant_history],
				ISNULL(B.[contract_number],'') AS contract_number, 
				ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 102),'') AS contract_date,
				B.sign AS op_sign
			FROM [dbo].[portion_history] B
			WHERE ((B.[id_history] IN (SELECT [id_history] FROM [dbo].[portion]))OR
				   (B.[id_history_will] IS NOT NULL))AND
				  ((B.[id_basin] BETWEEN @id_bas_from AND @id_bas_to)AND
				   (B.[id_regime] BETWEEN @id_rgm_from AND @id_rgm_to)AND
				   (B.[id_fish] BETWEEN @id_fs_from AND @id_fs_to)AND
				   (B.[id_region] BETWEEN @id_rgn_from AND @id_rgn_to))
		UNION ALL
			SELECT	A.[id_portion_actual] AS [id_portion_actual],
					C.[id_history] AS [id_portion],
					C.[id_history_was] AS [id_portion_was],
					C.[id_basin], 
					C.[id_regime],
					C.[id_fish], 
					C.[id_region],
					C.[portion],
					CONVERT(NVARCHAR(10), C.[date_open], 102) AS date_open, 
					CONVERT(NVARCHAR(10), C.[date_close], 102) AS date_close,
					C.[report_number], 
					ISNULL(CONVERT(NVARCHAR(10), C.[report_date], 102),'') AS report_date,
					C.[id_declarant_history],
					ISNULL(C.[contract_number],'') AS contract_number, 
					ISNULL(CONVERT(NVARCHAR(10), C.[contract_date], 102),'') AS contract_date,
					C.sign AS op_sign
			FROM [dbo].[portion_history] C
			JOIN portion_children A ON A.[id_portion_was]=C.[id_history]
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
    --добавлено 13-07-2017 sign=6 - изменение записи доли(корректировка ошибок ввода)
    WHERE FA.op_sign <> 6
	ORDER BY id_portion_actual, date_open;
END
GO
