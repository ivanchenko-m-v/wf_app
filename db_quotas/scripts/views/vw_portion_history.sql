CREATE VIEW vw_portion_history AS	
	SELECT P.[id_history],
		   P.[id_history_was],
		   P.[id_basin], 
		   B.[basin], 
		   P.[id_regime], 
		   R.[regime], 
		   P.[id_fish], 
		   F.[fish], 
		   P.[id_region], 
		   RG.[region], 
		   CONVERT(REAL, P.[portion]) AS portion, 
		   CONVERT(NVARCHAR(16), P.[date_open], 104) AS date_open, 
		   CONVERT(NVARCHAR(16), P.[date_close], 104) AS date_close, 
		   P.[report_number], 
		   CONVERT(NVARCHAR(16), P.[report_date], 104) AS report_date, 
		   D.[id_declarant], 
		   D.[id_declarant_history], 
		   D.[id_declarant_history_was], 
		   D.[declarant], 
		   D.[inn], 
		   ISNULL(P.[contract_number],'') AS contract_number, 
		   ISNULL(CONVERT(NVARCHAR(16), P.[contract_date], 104),'') AS contract_date, 
		   ISNULL(P.[transfer_reason], '') AS transfer_reason,
		   ISNULL(S.[sign], '') AS id_sign,
		   ISNULL(S.[sign_name], '') AS sign_name
		FROM 
			(((((
			[limits_2009c].[dbo].[portion_history] AS P INNER JOIN [limits_2009c].[dbo].[declarant_history] AS D ON P.id_declarant_history=D.id_declarant_history)
				INNER JOIN [limits_2009c].[dbo].[regime] AS R ON P.id_regime=R.id_regime)
				INNER JOIN  [limits_2009c].[dbo].[fish] AS F ON P.id_fish=F.id_fish)
				INNER JOIN [limits_2009c].[dbo].[region] AS RG ON P.id_region=RG.id_region)
				INNER JOIN [limits_2009c].[dbo].[basin] AS B ON P.id_basin=B.id_basin)
				LEFT OUTER JOIN [limits_2009c].[dbo].[sign] AS S ON P.[sign]=S.[sign];