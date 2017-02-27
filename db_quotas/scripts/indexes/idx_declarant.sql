--declarant
--[id_declarant_history_was]
CREATE INDEX idx_declarant_history_was 
    ON [dbo].[declarant] ( [id_declarant_history_was] );
GO
--[id_declarant]
CREATE INDEX idx_declarant 
    ON [dbo].[declarant] ( [id_declarant] );
GO