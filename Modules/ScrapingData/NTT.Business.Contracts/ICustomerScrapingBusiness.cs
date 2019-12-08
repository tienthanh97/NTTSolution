using NTT.Model.ScrapingData;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Contract.ScrapingData
{
    public interface ICustomerScrapingBusiness
    {
        int StoreCustomerData(IEnumerable<CustomerModel> data);
    }
}
