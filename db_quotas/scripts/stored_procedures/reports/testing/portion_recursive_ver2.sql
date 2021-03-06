USE limits_2009c
GO

	DECLARE @id_portion INT;
	DECLARE @id_basin INT;
	DECLARE @id_regime INT;
	DECLARE @id_fish INT;
	DECLARE @id_region INT;

	--service variables
	DECLARE @id_from int, @id_to int;
	DECLARE @id_bas_from int, @id_bas_to int;
	DECLARE @id_rgm_from int, @id_rgm_to int;
	DECLARE @id_fs_from int, @id_fs_to int;
	DECLARE @id_rgn_from int, @id_rgn_to int;
	--
	--set @id_portion = 32622;--;
	SET @id_portion = 0;--;
	SET @id_basin = 0;
	SET @id_regime = 0;
	SET @id_fish = 0;
	SET @id_region = 0;
	--@id_portion
	SET @id_from = @id_portion;
	IF @id_portion <> 0  
		SET @id_to = @id_portion; --only one
	ELSE 
		SET @id_to = 0x7FFFFFFF; --max int value (all)
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
				--CONVERT(NVARCHAR(32), B.[portion]) AS portion, 
				B.[portion], 
				CONVERT(NVARCHAR(10), B.[date_open], 104) AS date_open, 
				CONVERT(NVARCHAR(10), B.[date_close], 104) AS date_close,
				B.[report_number], 
				CONVERT(NVARCHAR(10), B.[report_date], 104) AS report_date, 
				B.[id_declarant_history],
				ISNULL(B.[contract_number],'') AS contract_number, 
				ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 104),'') AS contract_date
			FROM [dbo].[portion_history] B 
			WHERE (B.[id_history] BETWEEN @id_from AND @id_to)AND
				  (B.[id_basin] BETWEEN @id_bas_from AND @id_bas_to)AND
				  (B.[id_regime] BETWEEN @id_rgm_from AND @id_rgm_to)AND
				  (B.[id_fish] BETWEEN @id_fs_from AND @id_fs_to)AND
				  (B.[id_region] BETWEEN @id_rgn_from AND @id_rgn_to)
		UNION ALL
			SELECT	A.[id_portion_actual] AS [id_portion_actual],
					B.[id_history] AS [id_portion],
					B.[id_history_was] AS [id_portion_was],
					B.[id_basin], 
					B.[id_regime],
					B.[id_fish], 
					B.[id_region],
					--CONVERT(NVARCHAR(32), B.[portion]) AS portion, 
					B.[portion],
					CONVERT(NVARCHAR(10), B.[date_open], 104) AS date_open, 
					CONVERT(NVARCHAR(10), B.[date_close], 104) AS date_close,
					B.[report_number], 
					CONVERT(NVARCHAR(10), B.[report_date], 104) AS report_date, 
					B.[id_declarant_history],
					ISNULL(B.[contract_number],'') AS contract_number, 
					ISNULL(CONVERT(NVARCHAR(10), B.[contract_date], 104),'') AS contract_date
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
	GROUP BY id_portion_actual, basin, regime, fish, region,
		     portion, date_open, date_close, report_number, report_date,
		     declarant, inn, contract_number, contract_date
	ORDER BY id_portion_actual, date_open;

	go