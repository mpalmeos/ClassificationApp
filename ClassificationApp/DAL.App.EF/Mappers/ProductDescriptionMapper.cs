using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductDescriptionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDescription))
            {
                // map internal to external
                return MapFromDomain((internalDTO.ProductDescription) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDescription))
            {
                // map external to internal
                return MapFromDAL((externalDTO.ProductDescription) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDescription MapFromDomain(internalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new externalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromDomain(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromDomain(productDescription.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDescription MapFromDAL(externalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new internalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromDAL(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromDAL(productDescription.Product)
            };
            return res;
        }
    }
}