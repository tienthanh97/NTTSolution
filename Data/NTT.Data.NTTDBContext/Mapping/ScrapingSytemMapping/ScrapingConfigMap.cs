using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.ScrapingSytemEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext.Mapping.ScrapingSytemMapping
{

    [DBContext(Name = "ScrapingSystemDbContext")]
    public partial class ScrapingConfigMap : TrackingSystemEntityTypeConfiguration<ScrapingConfig>
    {
        public override void Configure(EntityTypeBuilder<ScrapingConfig> builder)
        {
            builder.ToTable("ScrapingConfig");
        }
    }
}
