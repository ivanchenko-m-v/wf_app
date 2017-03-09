/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 09-03-2017
-- Update date: 09-03-2017
-- Description:	portion actual current id for following 
--              tracking all the portion history
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE FUNCTION [dbo].[fn_portion_actual]
(
	@id_portion int
)
RETURNS INT
AS
BEGIN
	DECLARE @id_result int;

	IF EXISTS(
				SELECT [id_history] 
				FROM [dbo].[portion]
				WHERE [id_history] = @id_portion
			 )
	BEGIN
		RETURN @id_portion;
	END;

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
				WHERE(A.[id_history_was]=@id_portion)
		UNION ALL --последователи
			SELECT	
					B.[id_history] AS [id_portion],
					C.[id_portion] AS [id_portion_was]
			FROM [dbo].[portion_history] B 
				JOIN portion_followers C ON C.[id_portion]=B.[id_history_was]
	)
	/*
	SELECT FA.id_portion, FA.id_portion_was
	FROM portion_followers FA
	*/
	SELECT @id_result=MAX(FA.id_portion)
	FROM portion_followers FA;

	RETURN @id_result;
END
