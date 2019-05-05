using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductNameMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductName))
            {
                // map internal to external
                return MapFromDomain((internalDTO.ProductName) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductName))
            {
                // map external to internal
                return MapFromDAL((externalDTO.ProductName) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductName MapFromDomain(internalDTO.ProductName productName)
        {
            var res = productName == null ? null : new externalDTO.ProductName()
            {
                Id = productName.Id,
                ProductNameValue = productName.ProductNameValue
            };
            return res;
        }
        
        public static internalDTO.ProductName MapFromDAL(externalDTO.ProductName productName)
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