--limits
--[id_declarant]
CREATE INDEX idx_limits_declarant 
    ON [dbo].[limits] ( [id_declarant] );
GO
--[id_basin]
CREATE INDEX idx_limits_basin
    ON [dbo].[limits] ( [id_basin] );
GO
--[id_regime]
CREATE INDEX idx_limits_regime
    ON [dbo].[limits] ( [id_regime] );
GO
--[id_region]
CREATE INDEX idx_limits_region
    ON [dbo].[limits] ( [id_region] );
GO
--[id_fish]
CREATE INDEX idx_limits_fish
    ON [dbo].[limits] ( [id_fish] );
GO
--[id_subject]
CREATE INDEX idx_limits_subject
    ON [dbo].[limits] ( [id_subject] );
GO
--[id_unit]
CREATE INDEX idx_limits_unit
    ON [dbo].[limits] ( [id_unit] );
GO