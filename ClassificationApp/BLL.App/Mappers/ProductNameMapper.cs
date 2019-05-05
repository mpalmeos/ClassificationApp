using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductNameMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductName))
            {
                // map internal to external
                return MapFromDAL((internalDTO.ProductName) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductName))
            {
                // map external to internal
                return MapFromBLL((externalDTO.ProductName) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductName MapFromDAL(internalDTO.ProductName productName)
        {
            var res = productName == null ? null : new externalDTO.ProductName()
            {
                Id = productName.Id,
                ProductNameValue = productName.ProductNameValue
            };
            return res;
        }
        
        public static internalDTO.ProductName MapFromBLL(externalDTO.ProductName productName)
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