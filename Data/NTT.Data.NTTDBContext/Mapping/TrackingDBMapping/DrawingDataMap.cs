using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.PrototypeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    [DBContext(Name = "TrackingNpgDBContext")]
    public class DrawingDataMap : TrackingSystemEntityTypeConfiguration<DrawingData>
    {
        public override void Configure(EntityTypeBuilder<DrawingData> builder)
        {
            builder.ToTable("DrawingData");
        }
    }
}
