SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 16-02-2017
-- Update date: 17-02-2017
-- Description:	fish catch for 2 years 
-- with catching percent less than @nPercent
-- @StatType defines type of accounting, must be 'o', 's' or 'so'
-- ============================================================================
*/
CREATE PROCEDURE sp_select_catch_2_years
	-- Add the parameters for the stored procedure here
	@nYear1 int, 
	@nYear2 int, 
	@nPercent int,
	@StatType NVARCHAR(2),
	@debug bit = 0
AS
BEGIN
--
	 DECLARE	@sql NVARCHAR(4000), 
				@catch_vol_field NVARCHAR(32), 
				@s_percent NVARCHAR(8), @s_y1 NVARCHAR(8), @s_y2 NVARCHAR(8);

	--INT params to NVARCHAR
	SET @s_percent = CONVERT(NVARCHAR(8), @nPercent);
	SET @s_y1 = CONVERT(NVARCHAR(8), @nYear1);
	SET @s_y2 = CONVERT(NVARCHAR(8), @nYear2);
	SET @catch_vol_field = '';
	--
	IF 'S'=UPPER(@StatType)
		SET @catch_vol_field = '[catch_volume_stat]';
	--
	IF 'O'=UPPER(@StatType)
		SET @catch_vol_field = '[catch_volume_oper]';
	--
	IF 'SO'=UPPER(@StatType)
		SET @catch_vol_field = '[catch_volume_stat_oper]';

	IF LEN(@catch_vol_field)=0 RETURN;
	--
	 SET @sql =	N'SELECT	 LM1.[id_basin]' +
				N',BS.[basin]' +
				N',LM1.[id_subject]' +
				N',SB.[subject]' +
				N',LM1.[id_declarant]' +
				N',DC.[declarant]' +
				N',DC.[inn]' +
				N',LM1.[id_regime]' +
				N',RM.[regime]' +
				N',LM1.[id_region]' +
				N',RG.[region]' +
				N',LM1.[id_fish]' +
				N',FS.[fish]' +
				N',LM1.[id_unit]' +
				N',UN.[unit]' +
				N',LM1.[portion]' +
				N',LM1.[limits_volume] AS limits_1' +
				N',ISNULL(LM1.' + @catch_vol_field + N', 0) as catch_stat_1' +
				N',(ISNULL(LM1.' + @catch_vol_field + N', 0) / LM1.[limits_volume])*100 AS percent_1' +
				N',LM2.[limits_volume] as limits_2' +
				N',ISNULL(LM2.' + @catch_vol_field + N', 0) as catch_stat_2' +
				N',(ISNULL(LM2.' + @catch_vol_field + N', 0) / LM2.[limits_volume])*100 AS percent_2 ' +
				N' FROM ' +
				N'(((((((' +
				N'(select	[id_basin],[id_subject],[id_declarant],[id_regime],[id_region],' +
				N'[id_fish],[id_unit],[portion],[limits_volume],' + @catch_vol_field + ' ' +
				N'from [limits_2009c].[dbo].[limits_catch] ' +
				N'where (year([date])=' + @s_y1 + ')and([limits_volume] is not null)' +
				N') LM1 FULL OUTER JOIN' +
				N'(select [id_basin],[id_subject],[id_declarant],[id_regime],[id_region],' +
				N'[id_fish],[id_unit],[portion],[limits_volume],' + @catch_vol_field + ' ' +
				N'from [limits_2009c].[dbo].[limits_catch] ' + 
				N'where (year([date])=' + @s_y2 + ')and([limits_volume] is not null)' +
				N') LM2 ON' +
				N'((LM1.[id_basin]=LM2.[id_basin])and(LM1.[id_subject]=LM2.[id_subject])and' +
				N'(LM1.[id_declarant]=LM2.[id_declarant])and(LM1.[id_regime]=LM2.[id_regime])and' +
				N'(LM1.[id_region]=LM2.[id_region])and(LM1.[id_fish]=LM2.[id_fish])and' +
				N'(LM1.[id_unit]=LM2.[id_unit]))' +
				N') INNER JOIN [limits_2009c].[dbo].[basin] BS ON LM1.[id_basin]=BS.[id_basin]' +
				N') INNER JOIN [limits_2009c].[dbo].[subject] SB ON LM1.[id_subject]=SB.[id_subject]' +
				N') INNER JOIN [limits_2009c].[dbo].[declarant] DC ON LM1.[id_declarant]=DC.[id_declarant]' +
				N') INNER JOIN [limits_2009c].[dbo].[regime] RM ON LM1.[id_regime]=RM.[id_regime]' +
				N') INNER JOIN [limits_2009c].[dbo].[region] RG ON LM1.[id_region]=RG.[id_region]' +
				N') INNER JOIN [limits_2009c].[dbo].[fish] FS ON LM1.[id_fish]=FS.[id_fish]' +
				N') INNER JOIN [limits_2009c].[dbo].[unit] UN ON LM1.[id_unit]=UN.[id_unit] ' +
				N'WHERE ((ISNULL(LM1.' + @catch_vol_field + ', 0) / LM1.[limits_volume])*100<' + @s_percent + ')AND' +
				N'((ISNULL(LM2.' + @catch_vol_field + ', 0) / LM2.[limits_volume])*100<' + @s_percent + ')' +
				N' ORDER BY LM1.[id_regime],DC.[declarant],LM1.[id_region];';


	IF @debug=1 PRINT @sql;

	EXEC(@sql);
--
END
GO
