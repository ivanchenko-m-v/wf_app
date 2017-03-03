/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 02-03-2017
-- Update date: 03-03-2017
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
							   [id_declarant_history],[id_declarant]
							  ,[date_registration],[declarant]
							  ,[work_number],[declarant_type]
							  ,[address],[postal_address]
							  ,[director],[phone],[fax],[telex],[e_mail]
							  ,[declarant_full],[inn],[kpp],[reg_number]
							  ,[OKPO],[OKATO],[OKVED],[KOPF],[KFS]
							  ,[date_expiration],[id_own],[own]
							  ,[note],[responsible],[juridical],[timestamp_]
							  ,[del_comment],[id_declarant_history_was],[sign]							  
							  )
	AS 
	(
	SELECT	 DH.[id_declarant_history],DH.[id_declarant]
			,DH.[date_registration],DH.[declarant]
			,DH.[work_number],DH.[declarant_type]
			,DH.[address],DH.[postal_address]
			,DH.[director],DH.[phone],DH.[fax],DH.[telex],DH.[e_mail]
			,DH.[declarant_full],DH.[inn],DH.[kpp],DH.[reg_number]
			,DH.[OKPO],DH.[OKATO],DH.[OKVED],DH.[KOPF],DH.[KFS]
			,DH.[date_expiration],DH.[id_own],DH.[own]
			,DH.[note],DH.[responsible],DH.[juridical],DH.[timestamp_]
			,DH.[del_comment],DH.[id_declarant_history_was],DH.[sign]							  
		FROM [dbo].[declarant_history] AS DH
		WHERE DH.[id_declarant_history]=@id_declarant_history
		UNION ALL
		SELECT	 DH.[id_declarant_history],DH.[id_declarant]
				,DH.[date_registration],DH.[declarant]
				,DH.[work_number],DH.[declarant_type]
				,DH.[address],DH.[postal_address]
				,DH.[director],DH.[phone],DH.[fax],DH.[telex],DH.[e_mail]
				,DH.[declarant_full],DH.[inn],DH.[kpp],DH.[reg_number]
				,DH.[OKPO],DH.[OKATO],DH.[OKVED],DH.[KOPF],DH.[KFS]
				,DH.[date_expiration],DH.[id_own],DH.[own]
				,DH.[note],DH.[responsible],DH.[juridical],DH.[timestamp_]
				,DH.[del_comment],DH.[id_declarant_history_was],DH.[sign]	
		FROM [dbo].[declarant_history] AS DH
		JOIN declarant_forerunners AS DFR ON DFR.[id_declarant_history_was] = DH.[id_declarant_history]
	)
	SELECT 	 [id_declarant_history],[id_declarant]
			,[date_registration],[declarant]
			,[work_number],[declarant_type]
			,[address],[postal_address]
			,[director],[phone],[fax],[telex],[e_mail]
			,[declarant_full],[inn],[kpp],[reg_number]
			,[OKPO],[OKATO],[OKVED],[KOPF],[KFS]
			,[date_expiration],[id_own],[own]
			,[note],[responsible],[juridical],[timestamp_]
			,[del_comment],[id_declarant_history_was],[sign]
	FROM declarant_forerunners ORDER BY id_declarant_history DESC;
END
