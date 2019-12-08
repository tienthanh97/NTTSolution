using Microsoft.EntityFrameworkCore;
using NTT.Data.EntityModel.BaseEntitys;
using NTT.Data.NTTDBContext.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NTT.Data.NTTDBContext.NTTContexts
{
    public class TrackingNpgDBContext : NTTDBContextBase
    {
        public TrackingNpgDBContext(DbContextOptions<TrackingNpgDBContext> options) : base(options)
        {

        }

        protected override string ContextName => nameof(TrackingNpgDBContext);
    }
}
