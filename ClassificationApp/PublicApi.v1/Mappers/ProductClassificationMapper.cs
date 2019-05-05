using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductClassificationMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductClassification))
            {
                // map internal to external
                return MapFromBLL((internalDTO.ProductClassification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductClassification))
            {
                // map external to internal
                return MapFromExternal((externalDTO.ProductClassification) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductClassification MapFromBLL(internalDTO.ProductClassification productClassification)
        {
            var res = productClassification == null ? null : new externalDTO.ProductClassification()
            {
                Id = productClassification.Id,
                ProductClassificationValue = productClassification.ProductClassificationValue
            };
            return res;
        }
        
        public static internalDTO.ProductClassification MapFromExternal(externalDTO.ProductClassification productClassification)
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