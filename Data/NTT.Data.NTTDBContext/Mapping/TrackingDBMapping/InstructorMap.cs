

namespace NTT.Data.NTTDBContext.Mapping.TrackingDBMapping
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using NTT.Data.EntityModel.PrototypeEntity;

    [DBContext(Name = "PrototypeDBContext")]
    public class InstructorMap : TrackingSystemEntityTypeConfiguration<Instructor>
    {
        public override void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor");
            //builder.HasData
            //     (
            //     new
            //     {

            //         FirstMidName = "Kim",
            //         LastName = "Abercrombie",
            //         HireDate = DateTime.Parse("1995-03-11")
            //     },
            //    new
            //    {

            //        FirstMidName = "Fadi",
            //        LastName = "Fakhouri",
            //        HireDate = DateTime.Parse("2002-07-06")
            //    },
            //    new
            //    {

            //        FirstMidName = "Roger",
            //        LastName = "Harui",
            //        HireDate = DateTime.Parse("1998-07-01")
            //    },
            //    new
            //    {

            //        FirstMidName = "Candace",
            //        LastName = "Kapoor",
            //        HireDate = DateTime.Parse("2001-01-15")
            //    },
            //    new
            //    {

            //        FirstMidName = "Roger",
            //        LastName = "Zheng",
            //        HireDate = DateTime.Parse("2004-02-12")
            //    }
            //    );


        }
    }
}
