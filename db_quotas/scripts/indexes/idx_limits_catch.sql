--limits_catch
--[id_declarant]
CREATE INDEX idx_limits_catch_declarant 
    ON [dbo].[limits_catch] ( [id_declarant] );
GO
--[id_basin]
CREATE INDEX idx_limits_catch_basin
    ON [dbo].[limits_catch] ( [id_basin] );
GO
--[id_regime]
CREATE INDEX idx_limits_catch_regime
    ON [dbo].[limits_catch] ( [id_regime] );
GO
--[id_region]
CREATE INDEX idx_limits_catch_region
    ON [dbo].[limits_catch] ( [id_region] );
GO
--[id_fish]
CREATE INDEX idx_limits_catch_fish
    ON [dbo].[limits_catch] ( [id_fish] );
GO
--[id_subject]
CREATE INDEX idx_limits_catch_subject
    ON [dbo].[limits_catch] ( [id_subject] );
GO
--[id_unit]
CREATE INDEX idx_limits_catch_unit
    ON [dbo].[limits_catch] ( [id_unit] );
GO
--[portion_sign]
CREATE INDEX idx_limits_catch_portion_sign
    ON [dbo].[limits_catch] ( [portion_sign] );
GO
--[date]
CREATE INDEX idx_limits_catch_date
    ON [dbo].[limits_catch] ( [date] );
GO