using NTT.Contract.ScrapingData;
using NTT.Data.EntityModel.RealEstateEntity;
using NTT.Data.Repositories;
using NTT.Model.ScrapingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTT.Business.ScrapingData
{
    public class CustomerScrapingBusiness : ICustomerScrapingBusiness
    {
        private readonly IRepository<CustomerScraping> _customerScrapingRepository;

        public CustomerScrapingBusiness(IRepository<CustomerScraping> customerScrapingRepository)
        {
            _customerScrapingRepository = customerScrapingRepository;  
        }
        public int StoreCustomerData(IEnumerable<CustomerModel> data)
        {
            int result = 0;
            if (data != null && data.Any())
            {
                var entityData = data.Select(s => new CustomerScraping
                {
                    Name=s.Name,
                    Address=s.Address,
                    PhoneNumber=s.PhoneNumber,
                    EmailDrawing =s.Email
                }).ToList();
                _customerScrapingRepository.Insert(entityData);
                result = entityData.Count;
            }
            return result;
        }
    }
}
