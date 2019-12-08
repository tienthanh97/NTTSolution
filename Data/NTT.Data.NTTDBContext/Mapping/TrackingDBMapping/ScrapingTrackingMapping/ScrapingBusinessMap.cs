using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.RealEstateEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping.ScrapingTrackingMapping
{
    [DBContext(Name = "TrackingNpgDBContext")]
    public class ScrapingBusinessMap : TrackingSystemEntityTypeConfiguration<ScrapingBusiness>
    {
        public override void Configure(EntityTypeBuilder<ScrapingBusiness> builder)
        {
            builder.ToTable("ScrapingBusiness");
        }
    }
}
