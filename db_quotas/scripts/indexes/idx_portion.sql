--portion
--[id_declarant]
CREATE INDEX idx_portion_declarant 
    ON [dbo].[portion] ( [id_declarant] );
GO
--[id_basin]
CREATE INDEX idx_portion_basin
    ON [dbo].[portion] ( [id_basin] );
GO
--[id_regime]
CREATE INDEX idx_portion_regime
    ON [dbo].[portion] ( [id_regime] );
GO
--[id_region]
CREATE INDEX idx_portion_region
    ON [dbo].[portion] ( [id_region] );
GO
--[id_fish]
CREATE INDEX idx_portion_fish
    ON [dbo].[portion] ( [id_fish] );
GO
--[id_subject]
CREATE INDEX idx_portion_subject
    ON [dbo].[portion] ( [id_subject] );
GO