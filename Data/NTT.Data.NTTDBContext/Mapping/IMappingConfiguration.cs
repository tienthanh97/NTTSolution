﻿
namespace NTT.Data.NTTDBContext.Mapping
{
    using Microsoft.EntityFrameworkCore;
    public interface IMappingConfiguration
    {
        /// <summary>
        /// Apply this mapping configuration
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
