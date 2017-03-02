SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 15-02-2017
-- Description:	fish catch for 2 years 
-- with catching percent less than @Percent
--- ============================================================================
*/
CREATE PROCEDURE sp_select_catch_2_years_ver1
	-- Add the parameters for the stored procedure here
	@Year1 int, 
	@Year2 int, 
	@Percent int,
	@StatType NVARCHAR(2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--
	IF 'O'=UPPER(@StatType)
		EXEC sp_select_catch_2_years_oper @Year1, @Year2, @Percent;
	--
	IF 'S'=UPPER(@StatType)
		EXEC sp_select_catch_2_years_stat @Year1, @Year2, @Percent;
	--
	IF 'SO'=UPPER(@StatType)
		EXEC sp_select_catch_2_years_so @Year1, @Year2, @Percent;
	--
END
GO
-------------------------------------------------------------------------------
--sp_select_catch_2_years_stat
-------------------------------------------------------------------------------
CREATE PROCEDURE sp_select_catch_2_years_stat
	-- Add the parameters for the stored procedure here
	@Year1 int, 
	@Year2 int, 
	@Percent int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT A.[id_basin] 
		  ,A.[id_subject]
		  ,A.[id_declarant]
		  ,A.[id_regime]
		  ,A.[id_region]
		  ,A.[id_fish]
		  ,A.[id_unit]
		  ,A.[portion] as portion_1
		  ,A.[limits_volume] as limits_1
		  ,ISNULL(A.[catch_volume_stat], 0) as catch_stat_1
		  ,(ISNULL(A.[catch_volume_stat], 0) / A.[limits_volume])*100 AS percent_1
		  ,B.[portion] as portion_2
		  ,B.[limits_volume] as limits_2
		  ,ISNULL(B.[catch_volume_stat], 0) as catch_stat_2
		  ,(ISNULL(B.[catch_volume_stat], 0) / B.[limits_volume])*100 AS percent_2
	  FROM 
	  (select	[id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_stat]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year1)and([limits_volume] is not null)
	  ) A FULL OUTER JOIN
	  (select [id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_stat]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year2)and([limits_volume] is not null)
	  ) B ON
	  ((A.id_basin=B.id_basin)and(A.id_subject=B.id_subject)and(A.id_declarant=B.id_declarant)and
		(A.id_regime=B.id_regime)and(A.id_region=B.id_region)and(A.id_fish=B.id_fish)and
		(A.id_unit=B.id_unit))
	 WHERE ((ISNULL(A.[catch_volume_stat], 0) / A.[limits_volume])*100<@Percent)AND((ISNULL(B.[catch_volume_stat], 0) / B.[limits_volume])*100<@Percent);
	 --
END
GO
-------------------------------------------------------------------------------
--sp_select_catch_2_years_oper
-------------------------------------------------------------------------------
CREATE PROCEDURE sp_select_catch_2_years_oper
	-- Add the parameters for the stored procedure here
	@Year1 int, 
	@Year2 int, 
	@Percent int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT A.[id_basin] 
		  ,A.[id_subject]
		  ,A.[id_declarant]
		  ,A.[id_regime]
		  ,A.[id_region]
		  ,A.[id_fish]
		  ,A.[id_unit]
		  ,A.[portion] as portion_1
		  ,A.[limits_volume] as limits_1
		  ,ISNULL(A.[catch_volume_oper], 0) as catch_stat_1
		  ,(ISNULL(A.[catch_volume_oper], 0) / A.[limits_volume])*100 AS percent_1
		  ,B.[portion] as portion_2
		  ,B.[limits_volume] as limits_2
		  ,ISNULL(B.[catch_volume_oper], 0) as catch_stat_2
		  ,(ISNULL(B.[catch_volume_oper], 0) / B.[limits_volume])*100 AS percent_2
	  FROM 
	  (select	[id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_oper]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year1)and([limits_volume] is not null)
	  ) A FULL OUTER JOIN
	  (select [id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_oper]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year2)and([limits_volume] is not null)
	  ) B ON
	  ((A.id_basin=B.id_basin)and(A.id_subject=B.id_subject)and(A.id_declarant=B.id_declarant)and
		(A.id_regime=B.id_regime)and(A.id_region=B.id_region)and(A.id_fish=B.id_fish)and
		(A.id_unit=B.id_unit))
	 WHERE ((ISNULL(A.[catch_volume_oper], 0) / A.[limits_volume])*100<@Percent)AND((ISNULL(B.[catch_volume_oper], 0) / B.[limits_volume])*100<@Percent);
	 --
END
GO
-------------------------------------------------------------------------------
--sp_select_catch_2_years_so
-------------------------------------------------------------------------------
CREATE PROCEDURE sp_select_catch_2_years_so
	-- Add the parameters for the stored procedure here
	@Year1 int, 
	@Year2 int, 
	@Percent int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT A.[id_basin] 
		  ,A.[id_subject]
		  ,A.[id_declarant]
		  ,A.[id_regime]
		  ,A.[id_region]
		  ,A.[id_fish]
		  ,A.[id_unit]
		  ,A.[portion] as portion_1
		  ,A.[limits_volume] as limits_1
		  ,ISNULL(A.[catch_volume_stat_oper], 0) as catch_stat_1
		  ,(ISNULL(A.[catch_volume_stat_oper], 0) / A.[limits_volume])*100 AS percent_1
		  ,B.[portion] as portion_2
		  ,B.[limits_volume] as limits_2
		  ,ISNULL(B.[catch_volume_stat_oper], 0) as catch_stat_2
		  ,(ISNULL(B.[catch_volume_stat_oper], 0) / B.[limits_volume])*100 AS percent_2
	  FROM 
	  (select	[id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_stat_oper]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year1)and([limits_volume] is not null)
	  ) A FULL OUTER JOIN
	  (select [id_basin],[id_subject],[id_declarant],[id_regime],[id_region],
				[id_fish],[id_unit],[portion],[limits_volume],[catch_volume_stat_oper]
				from [limits_2009c].[dbo].[limits_catch] 
				where (year([date])=@Year2)and([limits_volume] is not null)
	  ) B ON
	  ((A.id_basin=B.id_basin)and(A.id_subject=B.id_subject)and(A.id_declarant=B.id_declarant)and
		(A.id_regime=B.id_regime)and(A.id_region=B.id_region)and(A.id_fish=B.id_fish)and
		(A.id_unit=B.id_unit))
	 WHERE ((ISNULL(A.[catch_volume_stat_oper], 0) / A.[limits_volume])*100<@Percent)AND((ISNULL(B.[catch_volume_stat_oper], 0) / B.[limits_volume])*100<@Percent);
	 --
END
GO
