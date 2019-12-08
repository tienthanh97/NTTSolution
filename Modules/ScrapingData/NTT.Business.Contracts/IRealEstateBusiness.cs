using NTT.Model.ScrapingData;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTT.Contract.ScrapingData
{
    public interface IRealEstateBusiness
    {
        IEnumerable<DrawingDataModel> GetAllDrawingData();


        IEnumerable<DrawingDataModel> Gettop100DrawingData();

        int StoreDrawingData(IEnumerable<DrawingDataModel> data);

        int UpdateDrawingStatus(IEnumerable<long> data);
    }
}
