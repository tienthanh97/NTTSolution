using NTT.Data.EntityModel.BaseEntitys;
using NTT.Data.EntityModel.PrototypeEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Data.EntityModel.RealEstateEntity
{
    public class CustomerScraping: BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmailDrawing { get; set; }
        public string Address { get; set; }
        public DrawingStatus Status { get; set; }
    }
}
