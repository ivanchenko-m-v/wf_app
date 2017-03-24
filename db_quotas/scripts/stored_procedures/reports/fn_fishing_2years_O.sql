/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 23-03-2017
-- Update date: 24-03-2017
-- Description:	Отчёт освоения вылова за 2 года, 
--              где процент освоения меньше заданного
--              по данным O(оперативка)
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE FUNCTION [dbo].[fn_fishing_2years_O]
(
	@nYear1 int, 
	@nYear2 int, 
	@nPercent int,
	@id_subject int = 0,
	@id_regime int = 0,
	@id_region int = 0,
	@id_WBR int = 0,
	@id_declarant int = 0
)
RETURNS @tb_ret TABLE
(
	[id_basin] int,
	[basin] nvarchar(32),
	[id_subject] int,
	[subject] nvarchar(32),
	[id_declarant] int,
	[declarant] nvarchar(128),
	[inn] nvarchar(16),
	[id_regime] int,
	[regime] nvarchar(64),
	[id_region] int,
	[region] nvarchar(64),
	[id_fish] int,
	[fish] nvarchar(64),
	[id_unit] int,
	[unit] nvarchar(16),
	[portion] decimal(38,17),
	[limits_1] decimal(38,17),
	[catch_stat_1] decimal(38,17),
	[percent_1] decimal(38,17),
	[limits_2] decimal(38,17),
	[catch_stat_2] decimal(38,17),
	[percent_2] decimal(38,17)
)
AS
BEGIN
	--service variables
	DECLARE @id_sbj_from INT, @id_sbj_to INT;
	DECLARE @id_rgm_from INT, @id_rgm_to INT;
	DECLARE @id_wbr_from INT, @id_wbr_to INT;
	DECLARE @id_rgn_from INT, @id_rgn_to INT;
	DECLARE @id_dcl_from INT, @id_dcl_to INT;
	--
	--@id_subject
	SET @id_sbj_from = @id_subject;
	IF @id_subject <> 0  
		SET @id_sbj_to = @id_subject;
	ELSE 
		SET @id_sbj_to = 0x7FFFFFFF; --max int value
	--@id_regime
	SET @id_rgm_from = @id_regime;
	IF @id_regime <> 0  
		SET @id_rgm_to = @id_regime;
	ELSE 
		SET @id_rgm_to = 0x7FFFFFFF; --max int value
	--@id_WBR
	SET @id_wbr_from = @id_WBR;
	IF @id_WBR <> 0  
		SET @id_wbr_to = @id_WBR;
	ELSE 
		SET @id_wbr_to = 0x7FFFFFFF; --max int value
	--@id_region
	SET @id_rgn_from = @id_region;
	IF @id_region <> 0  
		SET @id_rgn_to = @id_region;
	ELSE 
		SET @id_rgn_to = 0x7FFFFFFF; --max int value
	--@id_declarant
	SET @id_dcl_from = @id_declarant;
	IF @id_declarant <> 0  
		SET @id_dcl_to = @id_declarant;
	ELSE 
		SET @id_dcl_to = 0x7FFFFFFF; --max int value

	INSERT @tb_ret
		SELECT	 LM1.[id_basin], BS.[basin], LM1.[id_subject], SB.[subject],
				 LM1.[id_declarant], DC.[declarant], DC.[inn],
				 LM1.[id_regime], RM.[regime], LM1.[id_region], RG.[region],
				 LM1.[id_fish], FS.[fish], LM1.[id_unit], UN.[unit], 
				 (LM1.[portion] * 100) AS [portion], --in apps value displaying in percents
				 LM1.[limits_volume] AS limits_1,
				 ISNULL(LM1.[catch_volume_oper], 0) AS catch_stat_1,
				 (ISNULL(LM1.[catch_volume_oper], 0) / LM1.[limits_volume])*100 AS percent_1,
				 LM2.[limits_volume] AS limits_2,
				 ISNULL(LM2.[catch_volume_oper], 0) AS catch_stat_2,
				 (ISNULL(LM2.[catch_volume_oper], 0) / LM2.[limits_volume])*100 AS percent_2  
				 FROM 
				 ( --INNER JOIN [limits_2009c].[dbo].[fish] FS ON LM1.[id_fish]=FS.[id_fish])
				 ( --INNER JOIN [limits_2009c].[dbo].[region] RG ON LM1.[id_region]=RG.[id_region])
				 ( --INNER JOIN [limits_2009c].[dbo].[regime] RM ON LM1.[id_regime]=RM.[id_regime])
				 ( --INNER JOIN [limits_2009c].[dbo].[declarant] DC ON LM1.[id_declarant]=DC.[id_declarant]) 
				 ( --INNER JOIN [limits_2009c].[dbo].[subject] SB ON LM1.[id_subject]=SB.[id_subject])
				 ( --INNER JOIN [limits_2009c].[dbo].[basin] BS ON LM1.[id_basin]=BS.[id_basin])
					 (
						 ( SELECT	[id_basin], [id_subject], [id_declarant], [id_regime],
									[id_region], [id_fish], [id_unit], 
									[portion], [limits_volume], [catch_volume_oper] 
								FROM [dbo].[limits_catch] 
								WHERE (year([date])=@nYear1)AND([limits_volume] IS NOT NULL)AND
									  (([id_subject] BETWEEN @id_sbj_from AND @id_sbj_to)AND
									   ([id_regime] BETWEEN @id_rgm_from AND @id_rgm_to)AND
									   ([id_fish] BETWEEN @id_wbr_from AND @id_wbr_to)AND
									   ([id_region] BETWEEN @id_rgn_from AND @id_rgn_to)AND
									   ([id_declarant] BETWEEN @id_dcl_from AND @id_dcl_to))
						 ) LM1 FULL OUTER JOIN
						 ( SELECT   [id_basin], [id_subject], [id_declarant], [id_regime], 
									[id_region], [id_fish], [id_unit],
									[portion], [limits_volume], [catch_volume_oper]
								FROM [dbo].[limits_catch] 
								WHERE (year([date])=@nYear2)AND([limits_volume] IS NOT NULL)AND
									  (([id_subject] BETWEEN @id_sbj_from AND @id_sbj_to)AND
									   ([id_regime] BETWEEN @id_rgm_from AND @id_rgm_to)AND
									   ([id_fish] BETWEEN @id_wbr_from AND @id_wbr_to)AND
									   ([id_region] BETWEEN @id_rgn_from AND @id_rgn_to)AND
									   ([id_declarant] BETWEEN @id_dcl_from AND @id_dcl_to))
					 ) LM2 ON (
									(LM1.[id_basin]=LM2.[id_basin])AND(LM1.[id_subject]=LM2.[id_subject])AND
									(LM1.[id_declarant]=LM2.[id_declarant])AND(LM1.[id_regime]=LM2.[id_regime])AND
									(LM1.[id_region]=LM2.[id_region])AND(LM1.[id_fish]=LM2.[id_fish])AND
									(LM1.[id_unit]=LM2.[id_unit])
								  )
					 ) INNER JOIN [limits_2009c].[dbo].[basin] BS ON LM1.[id_basin]=BS.[id_basin]) 
					   INNER JOIN [limits_2009c].[dbo].[subject] SB ON LM1.[id_subject]=SB.[id_subject]) 
					   INNER JOIN [limits_2009c].[dbo].[declarant] DC ON LM1.[id_declarant]=DC.[id_declarant]) 
					   INNER JOIN [limits_2009c].[dbo].[regime] RM ON LM1.[id_regime]=RM.[id_regime]) 
					   INNER JOIN [limits_2009c].[dbo].[region] RG ON LM1.[id_region]=RG.[id_region]) 
					   INNER JOIN [limits_2009c].[dbo].[fish] FS ON LM1.[id_fish]=FS.[id_fish]) 
					   INNER JOIN [limits_2009c].[dbo].[unit] UN ON LM1.[id_unit]=UN.[id_unit] 
				WHERE ((ISNULL(LM1.[catch_volume_oper], 0) / LM1.[limits_volume])*100<@nPercent)AND
					  ((ISNULL(LM2.[catch_volume_oper], 0) / LM2.[limits_volume])*100<@nPercent) 
			    ORDER BY LM1.[id_regime], DC.[declarant], LM1.[id_region];
	RETURN
END
