CREATE PROCEDURE dbo.[sp_portion_recursive]
    --@param1 int = 0,
    --@param2 int  
AS
BEGIN
	WITH portion_children( 
							id_portion_actual, 
							id_portion, 
							id_portion_was 
						 )
	AS
	(
		SELECT	A.[id_history] AS [id_portion_actual],
				B.[id_history] AS [id_portion],
				B.[id_history_was] AS [id_portion_was]
			FROM [dbo].[portion] A INNER JOIN [dbo].[portion_history] B ON A.[id_history]=B.[id_history]
		UNION ALL
			SELECT	A.[id_portion_actual] AS [id_portion_actual],
					B.[id_history] AS [id_portion],
					B.[id_history_was] AS [id_portion_was]
			FROM [dbo].[portion_history] B
				JOIN portion_children A ON A.[id_portion_was]=B.[id_history]
		    WHERE B.[id_history] NOT IN (SELECT[id_history] FROM [dbo].[portion])
	)
	SELECT  FA.id_portion_actual, FA.id_portion, FA.id_portion_was,
		   ,FB.[id_basin],FB.[basin],FB.[id_regime],FB.[regime]
		   ,FB.[id_fish],FB.[fish],FB.[id_region],FB.[region]
		   ,FB.[portion],FB.[date_open],FB.[date_close]
		   ,FB.[report_number],FB.[report_date],FB.[id_declarant],FB.[id_declarant_history]
		   ,FB.[id_declarant_history_was],FB.[declarant],FB.[inn]
		   ,FB.[contract_number],FB.[contract_date],FB.[transfer_reason]
		   ,FB.[id_sign],FB.[sign_name]
	FROM portion_children FA INNER JOIN dbo.[vw_portion_history] FB ON FA.id_portion=FB.id_history
	--where id_portion_actual=32622
	--WHERE (id_regime=1)and(id_region=261)and(id_fish=166)
	ORDER BY id_portion_actual, id_portion_was, id_portion;
END
