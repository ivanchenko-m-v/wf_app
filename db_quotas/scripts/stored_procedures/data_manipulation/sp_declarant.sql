/**
-- ============================================================================
-- Author:		M.Ivanchenko
-- Create date: 21-03-2017
-- Update date: 21-03-2017
-- Description:	declarants list
--- ============================================================================
*/
/*
USE limits_2009c
GO
*/
CREATE PROCEDURE [dbo].[sp_declarant]
(
	@x_declarant nvarchar(256) = ''
)
AS
BEGIN
	IF @x_declarant = ''
		SELECT	[id_declarant_history],    
				[id_declarant],            
				[date_registration],       
				[declarant],               
				[work_number],             
				[declarant_type],          
				[address],                 
				[postal_address],          
				[director],                
				[phone],                   
				[fax],                     
				[telex],                   
				[e_mail],                  
				[declarant_full],          
				[inn],                     
				[kpp],                     
				[reg_number],              
				[OKPO],                    
				[OKATO],                   
				[OKVED],                   
				[KOPF],                    
				[KFS],                     
				[id_own],                  
				[own],                     
				[note],                    
				[juridical],               
				[id_declarant_history_was] 
			FROM dbo.[declarant];
	ELSE
		SELECT	[id_declarant_history],    
				[id_declarant],            
				[date_registration],       
				[declarant],               
				[work_number],             
				[declarant_type],          
				[address],                 
				[postal_address],          
				[director],                
				[phone],                   
				[fax],                     
				[telex],                   
				[e_mail],                  
				[declarant_full],          
				[inn],                     
				[kpp],                     
				[reg_number],              
				[OKPO],                    
				[OKATO],                   
				[OKVED],                   
				[KOPF],                    
				[KFS],                     
				[id_own],                  
				[own],                     
				[note],                    
				[juridical],               
				[id_declarant_history_was] 
			FROM dbo.[declarant]
			WHERE ([declarant] LIKE '%'+@x_declarant+'%')
			ORDER BY [declarant];
END;
