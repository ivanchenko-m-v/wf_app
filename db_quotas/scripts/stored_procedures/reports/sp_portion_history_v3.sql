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
--              - v3 - вариант, учитывающий только записи, у которых
--                      id_history_was=NULL
--                      или id_history в таблице передачи долей
--                          в поле (id_history_to)
-- ============================================================================
*/
/*
USE limits_2009c
GO
*/
/*
	WITH portion_followers( 
							id_portion,
							id_history, 
							id_history_was
					      )
	AS
	(
			SELECT	
					A.[id_history] AS [id_portion],
					A.[id_history] AS [id_history],
					A.[id_history_was] AS [id_history_was]
				FROM [limits_2009].[dbo].[portion_history] A 
				WHERE(A.[id_history] IN(SELECT [id_history] FROM [limits_2009].[dbo].[portion]))
		UNION ALL --последователи
			SELECT	
					C.[id_portion] AS [id_portion],
					B.[id_history] AS [id_history],
					B.[id_history_was] AS [id_history_was]
			FROM [limits_2009].[dbo].[portion_history] B 
				JOIN portion_followers C ON C.[id_history_was]=B.[id_history]
	)
	SELECT 
		    FA.id_portion
		   ,FA.id_history 
		   ,FA.id_history_was
		   ,VW.[id_declarant]
		   ,VW.[id_basin]
		   ,BS.[basin]
		   ,VW.[id_regime]
		   ,RG.[regime]
		   ,VW.[id_region]
		   ,RN.[region]
		   ,VW.[id_fish]
		   ,FS.[fish]
		   ,VW.[id_subject]
		   ,SB.[subject]
		   ,VW.[portion]
		   ,VW.[date_open]
		   ,VW.[date_close]
		   ,VW.[report_organization]
		   ,VW.[report_number]
		   ,VW.[report_date]
		   ,VW.[report_document]
		   ,VW.[contract_organization]
		   ,VW.[contract_number]
		   ,VW.[contract_date]
		   ,VW.[contract_cancel_organization]
		   ,VW.[contract_cancel_number]
		   ,VW.[contract_cancel_date]
		   ,VW.[contract_cancel_document]
		   ,VW.[transfer_number]
		   ,VW.[transfer_date]
		   ,VW.[transfer_reason]
		   ,VW.[note]
		   ,VW.[responsible]
		   ,VW.[timestamp_]
	FROM 
		portion_followers FA 
	INNER JOIN 
		 ( --dbo.[declarant] DCL
		 ( --dbo.[subject] SB
		 ( --dbo.[region] RN
		 ( --dbo.[fish] FSH
		 ( --dbo.[regime] RG
		 ( --dbo.[basin] BS
		 (	--VW
			SELECT
			   [id_history]
			  ,[id_declarant]
			  ,[id_basin]
			  ,[id_regime]
			  ,[id_region]
			  ,[id_fish]
			  ,[id_subject]
			  ,[portion]
			  ,[date_open]
			  ,[date_close]
			  ,[report_organization]
			  ,[report_number]
			  ,[report_date]
			  ,[report_document]
			  ,[contract_organization]
			  ,[contract_number]
			  ,[contract_date]
			  ,[contract_cancel_organization]
			  ,[contract_cancel_number]
			  ,[contract_cancel_date]
			  ,[contract_cancel_document]
			  ,[transfer_number]
			  ,[transfer_date]
			  ,[transfer_reason]
			  ,[note]
			  ,[responsible]
			  ,[timestamp_]
			  ,[id_history_was]
			  ,[id_declarant_history]
			  ,[sign]
			  ,[id_history_will]
		  FROM [limits_2009].[dbo].[portion_history]
		  -- выборка действующих долей квот
		  WHERE ([id_history] IN (SELECT [id_history] FROM [limits_2009].[dbo].[portion]))
		 UNION ALL
			 SELECT
			   [id_history]
			  ,[id_declarant]
			  ,[id_basin]
			  ,[id_regime]
			  ,[id_region]
			  ,[id_fish]
			  ,[id_subject]
			  ,[portion]
			  ,[date_open]
			  ,[date_close]
			  ,[report_organization]
			  ,[report_number]
			  ,[report_date]
			  ,[report_document]
			  ,[contract_organization]
			  ,[contract_number]
			  ,[contract_date]
			  ,[contract_cancel_organization]
			  ,[contract_cancel_number]
			  ,[contract_cancel_date]
			  ,[contract_cancel_document]
			  ,[transfer_number]
			  ,[transfer_date]
			  ,[transfer_reason]
			  ,[note]
			  ,[responsible]
			  ,[timestamp_]
			  ,[id_history_was]
			  ,[id_declarant_history]
			  ,[sign]
			  ,[id_history_will]
		  FROM [limits_2009].[dbo].[portion_history]
		  WHERE ([id_history] IN (SELECT [id_history_from] FROM [limits_2009].[dbo].[portion_limits_transfer] WHERE (portion_limit_flag=0)))
		 ) VW ON FA.id_history=VW.id_history )
		 INNER JOIN [limits_2009].[dbo].[basin] BS ON VW.id_basin=BS.id_basin ) 
		 INNER JOIN [limits_2009].[dbo].[regime] RG ON VW.id_regime=RG.id_regime ) 
		 INNER JOIN [limits_2009].[dbo].[fish] FS ON VW.id_fish=RG.id_fish ) 
		 INNER JOIN [limits_2009].[dbo].[region] RN ON VW.id_region=RN.id_region )
		 INNER JOIN [limits_2009].[dbo].[subject] SB ON VW.id_subject=SB.id_subject )
		 INNER JOIN [limits_2009].[dbo].[declarant] DCL ON VW.id_declarant=DCL.id_declarant )
	ORDER BY FA.id_portion, FA.id_history
*/
/**
 *
 *  fn_portion_actual_limits_2009 - выборка id действующей доли
 *                                  в БД limits_2009
 */
CREATE FUNCTION [dbo].[fn_portion_actual_limits_2009]
(
	@id_portion int
)
RETURNS INT
AS
BEGIN
	DECLARE @id_result int;

	IF EXISTS(
				SELECT [id_history] 
				FROM [dbo].[portion]
				WHERE [id_history] = @id_portion
			 )
	BEGIN
		RETURN @id_portion;
	END;

	WITH portion_followers( 
							id_portion, 
							id_portion_was
					      )
	AS
	(
			SELECT	
					A.[id_history] AS [id_portion],
					A.[id_history_was] AS [id_portion_was]
				FROM [limits_2009].[dbo].[portion_history] A 
				--WHERE(A.[id_history_was]=36680)
				WHERE(A.[id_history_was]=@id_portion)
		UNION ALL --последователи
			SELECT	
					B.[id_history] AS [id_portion],
					C.[id_portion] AS [id_portion_was]
			FROM [limits_2009].[dbo].[portion_history] B 
				JOIN portion_followers C ON C.[id_portion]=B.[id_history_was]
	)
	/*
	SELECT FA.id_portion, FA.id_portion_was
	FROM portion_followers FA
	*/
	SELECT @id_result=MAX(FA.id_portion)
	FROM portion_followers FA;

	IF @id_result IS NULL 
	BEGIN
		SET @id_result = @id_portion;
	END;

	RETURN @id_result;
END
/**
 *
 *  vw_portion_history - выборка действующих долей, и тех, которые когда-либо
 *                       передавались
 *
 */
CREATE VIEW vw_portion_history
AS
(
    SELECT
       [id_history]
      ,[id_declarant]
      ,[id_basin]
      ,[id_regime]
      ,[id_region]
      ,[id_fish]
      ,[id_subject]
      ,[portion]
      ,[date_open]
      ,[date_close]
      ,[report_organization]
      ,[report_number]
      ,[report_date]
      ,[report_document]
      ,[contract_organization]
      ,[contract_number]
      ,[contract_date]
      ,[contract_cancel_organization]
      ,[contract_cancel_number]
      ,[contract_cancel_date]
      ,[contract_cancel_document]
      ,[transfer_number]
      ,[transfer_date]
      ,[transfer_reason]
      ,[note]
      ,[responsible]
      ,[timestamp_]
      ,[id_history_was]
      ,[id_declarant_history]
      ,[sign]
      ,[id_history_will]
  FROM [limits_2009].[dbo].[portion_history]
  -- выборка действующих долей квот
  WHERE ([id_history] IN (SELECT [id_history] FROM [limits_2009].[dbo].[portion]))
 UNION ALL
     SELECT
       [id_history]
      ,[id_declarant]
      ,[id_basin]
      ,[id_regime]
      ,[id_region]
      ,[id_fish]
      ,[id_subject]
      ,[portion]
      ,[date_open]
      ,[date_close]
      ,[report_organization]
      ,[report_number]
      ,[report_date]
      ,[report_document]
      ,[contract_organization]
      ,[contract_number]
      ,[contract_date]
      ,[contract_cancel_organization]
      ,[contract_cancel_number]
      ,[contract_cancel_date]
      ,[contract_cancel_document]
      ,[transfer_number]
      ,[transfer_date]
      ,[transfer_reason]
      ,[note]
      ,[responsible]
      ,[timestamp_]
      ,[id_history_was]
      ,[id_declarant_history]
      ,[sign]
      ,[id_history_will]
  FROM [limits_2009].[dbo].[portion_history]
  WHERE ([id_history] IN (SELECT [id_history_from] FROM [limits_2009].[dbo].[portion_limits_transfer] WHERE (portion_limit_flag=0)))
);

/**
 *
 *  sp_portion_history_v3 - работает медленне всех,
 *  может не включать изъятые и доли с уменьшением значения
 *
 */
CREATE PROCEDURE [dbo].[sp_portion_history_v3]
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
				ISNULL(CONVERT(NVARCHAR(10), B.[report_date], 102),'') AS report_date,
				B.[id_declarant_history],
				ISNULL(B.[contract_number],'') AS contract_number,
				ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 102),'') AS contract_date
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
					ISNULL(CONVERT(NVARCHAR(10), C.[contract_date], 102),'') AS contract_date
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
    -- добавлено 13-07-2017.
    -- выбираем только те записи истории, которые есть в таблице передачи долей
    -- или первоначальную запись (C.[id_history_was]=null)
    WHERE (FA.[id_portion_was] is null) or (FA.[id_portion_was]=0)
           OR
          (FA.[id_portion] IN (SELECT id_history_to FROM portion_limits_transfer WHERE (portion_limit_flag=0)))
	ORDER BY id_portion_actual, date_open;
END
GO