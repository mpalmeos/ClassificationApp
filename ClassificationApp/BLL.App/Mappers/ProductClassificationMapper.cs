using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductClassificationMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductClassification))
            {
                // map internal to external
                return MapFromDAL((internalDTO.ProductClassification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductClassification))
            {
                // map external to internal
                return MapFromBLL((externalDTO.ProductClassification) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductClassification MapFromDAL(internalDTO.ProductClassification productClassification)
        {
            var res = productClassification == null ? null : new externalDTO.ProductClassification()
            {
                Id = productClassification.Id,
                ProductClassificationValue = productClassification.ProductClassificationValue
            };
            return res;
        }
        
        public static internalDTO.ProductClassification MapFromBLL(externalDTO.ProductClassification productClassification)
        {
            var res = productClassification == null ? null : new internalDTO.ProductClassification()
            {
                Id = productClassification.Id,
                ProductClassificationValue = productClassification.ProductClassificationValue
            };
            return res;
        }
    }
}