-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 16-02-2017
-- Update date: 22-02-2017
-- Description:	recursive select from region & region_p union into common 
-- table
--- ============================================================================

WITH region_slaves(id_region, id_region_parent, region)
AS (
SELECT	RP.id_region, 
		RP.id_region_parent, 
		R.region
    FROM [limits_2009c].[dbo].[region] AS R
    INNER JOIN [limits_2009c].[dbo].[region_p] AS RP ON RP.id_region = R.id_region 
    WHERE RP.id_region_parent=86
    UNION ALL
    SELECT	RP.id_region, 
			RP.id_region_parent, 
			R.region
    FROM [limits_2009c].[dbo].[region] AS R
    JOIN [limits_2009c].[dbo].[region_p] AS RP ON RP.id_region = R.id_region
    JOIN region_slaves AS RS ON RS.id_region = RP.id_region_parent
    )
--SELECT DISTINCT id_region, id_region_parent, region
SELECT id_region, id_region_parent, region
FROM region_slaves ORDER BY id_region_parent, id_region
GO 