using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.NTTDBContext
{
    public class DBContextAttribute:Attribute
    {
        /// <summary>
        /// Name of DB Context
        /// </summary>
        public string Name { get; set; }
        public DBContextAttribute()
        {
        }
    }
}
