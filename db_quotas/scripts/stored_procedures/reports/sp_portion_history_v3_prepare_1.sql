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
     ( --VW
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
	 ) VW ON FA.id_history=VW.id_history )
	 INNER JOIN [limits_2009].[dbo].[basin] BS ON VW.id_basin=BS.id_basin ) 
	 INNER JOIN [limits_2009].[dbo].[regime] RG ON VW.id_regime=RG.id_regime ) 
	 INNER JOIN [limits_2009].[dbo].[fish] FS ON VW.id_fish=RG.id_fish ) 
	 INNER JOIN [limits_2009].[dbo].[region] RN ON VW.id_region=RN.id_region )
	 INNER JOIN [limits_2009].[dbo].[subject] SB ON VW.id_subject=SB.id_subject )
	 INNER JOIN [limits_2009].[dbo].[declarant] DCL ON VW.id_declarant=DCL.id_declarant )