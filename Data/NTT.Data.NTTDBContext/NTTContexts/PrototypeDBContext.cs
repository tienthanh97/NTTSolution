using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext.NTTContexts
{
    public class PrototypeDBContext: NTTDBContextBase
    {
        public PrototypeDBContext(DbContextOptions<PrototypeDBContext> options) : base(options)
        {

        }

        protected override string ContextName => nameof(PrototypeDBContext);
       
    }
}
