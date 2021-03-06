USE [limits_2009c]
GO

declare @id_history int;
set @id_history=25491;--11652;--31183;--30710;----;31292--0;


	DECLARE @id_from int, @id_to int;
	--@id_history
	SET @id_from = @id_history;
	IF @id_history <> 0  
		SET @id_to = @id_history; --only one chain
	ELSE 
		SET @id_to = 0x7FFFFFFF; --max int value (all)

WITH portion_chain( 
						id_portion_actual, 
						id_portion, 
						id_portion_was 
				  )
AS
(
	SELECT	A.[id_history] AS [id_portion_actual],
			A.[id_history] AS [id_portion],
			A.[id_history_was] AS [id_portion_was]
		FROM [dbo].[portion] A --INNER JOIN [dbo].[portion_history] B ON A.[id_history]=B.[id_history_was]
		WHERE A.[id_history]=@id_portion_history
	UNION ALL
		SELECT	A.[id_portion_actual] AS [id_portion_actual],
				B.[id_history] AS [id_portion],
				B.[id_history_was] AS [id_portion_was]
		FROM [dbo].[portion_history] B
			JOIN portion_chain A ON A.[id_portion_was]=B.[id_history]
)
SELECT FA.id_portion_actual, FA.id_portion, FA.id_portion_was
FROM portion_chain FA
ORDER BY id_portion_actual, id_portion_was, id_portion;
/*
	WITH portion_forerunners( 
							id_portion, 
							id_portion_was
					  )
	AS
	(
			SELECT	
					A.[id_history] AS [id_portion],
					A.[id_history_was] AS [id_portion_was]
				FROM [dbo].[portion_history] A 
				WHERE(A.[id_history] BETWEEN @id_from AND @id_to)
		UNION ALL --предшественники
			SELECT	
					C.[id_portion] AS [id_portion],
					B.[id_history_was] AS [id_portion_was]
			FROM [dbo].[portion_history] B 
				JOIN portion_forerunners C ON C.[id_portion_was]=B.[id_history]
	)
	SELECT FA.id_portion, FA.id_portion_was
	FROM portion_forerunners FA
	--GO
UNION ALL
	WITH portion_followers( 
							id_portion, 
							id_portion_was
					      )
	AS
	(
			SELECT	
					A.[id_history] AS [id_portion],
					A.[id_history_was] AS [id_portion_was]
				FROM [dbo].[portion_history] A 
				WHERE(A.[id_history_was] BETWEEN @id_from AND @id_to)
		UNION ALL --последователи
			SELECT	
					C.[id_portion] AS [id_portion],
					B.[id_history_was] AS [id_portion_was]
			FROM [dbo].[portion_history] B 
				JOIN portion_followers C ON C.[id_portion]=B.[id_history_was]
	)
	SELECT FA.id_portion, FA.id_portion_was
	FROM portion_followers FA

	GO
	--ORDER BY id_portion_was, id_portion;
*/

--select * from dbo.portion where id_history in (25491,32402,30252,30253,35861,35862,31291,31292,31182,31183,30709,30710,29870,29871);