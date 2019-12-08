using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.EntityModel.PrototypeEntity
{
    public class DrawingData : BaseEntity
    {
        public string Data { get; set; }

        public int BusinessId { get; set; }

        public DrawingStatus Status { get; set; }
    }

    public enum DrawingStatus
    {
        New,
        Processing,
        Complete
    }
}
