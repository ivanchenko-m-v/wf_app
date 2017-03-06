CREATE PROCEDURE [dbo].[sp_portion_chain]
	@id_history int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

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
			FROM [dbo].[portion_history] A 
			WHERE (A.[id_history] BETWEEN @id_from AND @id_to)
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
END
