
using Microsoft.AspNetCore.Mvc;
using NTT.Contract.ScrapingData;
using NTT.Data.EntityModel.PrototypeEntity;
using NTT.Data.Repositories;
using NTT.Model.ScrapingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTT.Business.ScrapingData
{
    public class RealEstateBusiness : IRealEstateBusiness
    {
        private readonly IRepository<DrawingData> _drawingDataRepository;

        public RealEstateBusiness(IRepository<DrawingData> drawingDataRepository)
        {
            _drawingDataRepository = drawingDataRepository;
        }
        public IEnumerable<DrawingDataModel> GetAllDrawingData()
        {
            var result = _drawingDataRepository.Table.Where(x=>x.Status== DrawingStatus.New).Take(10).ToList()
                .Select(x => new DrawingDataModel
                {
                    Data = x.Data,
                    BusinessId = x.BusinessId,
                    Id = x.Id
                });

            return result;
        }

        public IEnumerable<DrawingDataModel> Gettop100DrawingData()
        {
            var result = _drawingDataRepository.Table.Where(x=>x.Status == DrawingStatus.New).Take(100).ToList()
                .Select(x => new DrawingDataModel
                {
                    Data = x.Data,
                    BusinessId = x.BusinessId,
                    Id = x.Id
                });

            return result;
        }

        public int StoreDrawingData(IEnumerable<DrawingDataModel> data)
        {
            int result = 0;
            if (data != null && data.Any())
            {

                var drawingEntity = data.Select(x => new DrawingData
                {
                    Data = x.Data,
                    BusinessId = x.BusinessId,
                    CreateDate = DateTime.Now,
                }).ToList();
                _drawingDataRepository.Insert(drawingEntity);
                result = drawingEntity.Count;  
            }
            return result;

        }

        public int UpdateDrawingStatus(IEnumerable<long> data)
        {
            int result = 0;
            var entityList=  _drawingDataRepository.Table.Where(x => data.Contains(x.Id)).ToList();
            foreach (var entity in entityList)
            {
                entity.Status = DrawingStatus.Complete;
            }

            _drawingDataRepository.Update(entityList);
            result = entityList.Count();
            return result;
        }
    }
}
