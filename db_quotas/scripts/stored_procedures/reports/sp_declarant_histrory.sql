/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 02-03-2017
-- Update date: 02-03-2017
-- Description:	declarant with his forerunners 
-- ============================================================================
*/
CREATE PROCEDURE [dbo].[sp_declarant_history]
	@id_declarant_history int = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	WITH declarant_forerunners( 
								id_declarant_history, 
								id_declarant, 
								id_declarant_history_was, 
								declarant, 
								date_expiry
							  )
	AS 
	(
	SELECT	DH.[id_declarant_history], 
			DH.[id_declarant], 
			DH.[id_declarant_history_was], 
			DH.[declarant],
			DH.[date_expiration]
		FROM [limits_2009c].[dbo].[declarant_history] AS DH
		WHERE DH.[id_declarant_history]=@id_declarant_history
		UNION ALL
		SELECT	DH.[id_declarant_history], 
				DH.[id_declarant], 
				DH.[id_declarant_history_was], 
				DH.[declarant],
				DH.[date_expiration]
		FROM [limits_2009c].[dbo].[declarant_history] AS DH
		JOIN declarant_forerunners AS DFR ON DFR.[id_declarant_history_was] = DH.[id_declarant_history]
	)
	SELECT id_declarant_history, id_declarant, id_declarant_history_was, declarant, date_expiry
	FROM declarant_forerunners ORDER BY id_declarant_history DESC
END
