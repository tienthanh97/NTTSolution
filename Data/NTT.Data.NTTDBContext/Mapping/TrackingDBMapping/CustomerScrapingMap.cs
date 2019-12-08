using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTT.Data.EntityModel.PrototypeEntity;
using NTT.Data.EntityModel.RealEstateEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    [DBContext(Name = "TrackingNpgDBContext")]
    public class CustomerScrapingMap : TrackingSystemEntityTypeConfiguration<CustomerScraping>
    {
        public override void Configure(EntityTypeBuilder<CustomerScraping> builder)
        {
            builder.ToTable("CustomerScraping");
        }
    }
}
