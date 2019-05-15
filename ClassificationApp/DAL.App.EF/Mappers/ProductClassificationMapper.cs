using System;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductClassificationMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductClassification))
            {
                // map internal to external
                return MapFromDomain((internalDTO.ProductClassification) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductClassification))
            {
                // map external to internal
                return MapFromDAL((externalDTO.ProductClassification) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductClassification MapFromDomain(internalDTO.ProductClassification productClassification)
        {
            var res = productClassification == null ? null : new externalDTO.ProductClassification()
            {
                Id = productClassification.Id,
                ProductClassificationValue = productClassification.ProductClassificationValue
            };
            return res;
        }
        
        public static internalDTO.ProductClassification MapFromDAL(externalDTO.ProductClassification productClassification)
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