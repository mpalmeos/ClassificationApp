using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductDescriptionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDescription))
            {
                // map internal to external
                return MapFromBLL((internalDTO.ProductDescription) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDescription))
            {
                // map external to internal
                return MapFromExternal((externalDTO.ProductDescription) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDescription MapFromBLL(internalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new externalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromBLL(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromBLL(productDescription.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDescription MapFromExternal(externalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new internalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromExternal(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromExternal(productDescription.Product)
            };
            return res;
        }
    }
}