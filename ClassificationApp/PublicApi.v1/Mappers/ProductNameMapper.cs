using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductNameMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductName))
            {
                // map internal to external
                return MapFromBLL((internalDTO.ProductName) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductName))
            {
                // map external to internal
                return MapFromExternal((externalDTO.ProductName) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductName MapFromBLL(internalDTO.ProductName productName)
        {
            var res = productName == null ? null : new externalDTO.ProductName()
            {
                Id = productName.Id,
                ProductNameValue = productName.ProductNameValue
            };
            return res;
        }
        
        public static internalDTO.ProductName MapFromExternal(externalDTO.ProductName productName)
        {
            var res = productName == null ? null : new internalDTO.ProductName()
            {
                Id = productName.Id,
                ProductNameValue = productName.ProductNameValue
            };
            return res;
        }
    }
}