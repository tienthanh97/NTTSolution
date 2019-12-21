namespace NTT.Data.NTTDBContext.NTTContexts
{
    using Microsoft.EntityFrameworkCore;
    public class ScrapingSystemDbContext : NTTDBContextBase
    {
        public ScrapingSystemDbContext(DbContextOptions<ScrapingSystemDbContext> options) : base(options)
        {

        }

        protected override string ContextName => nameof(ScrapingSystemDbContext);
    }
}
