using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductDescriptionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDescription))
            {
                // map internal to external
                return MapFromDAL((internalDTO.ProductDescription) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDescription))
            {
                // map external to internal
                return MapFromBLL((externalDTO.ProductDescription) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDescription MapFromDAL(internalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new externalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromDAL(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromDAL(productDescription.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDescription MapFromBLL(externalDTO.ProductDescription productDescription)
        {
            var res = productDescription == null ? null : new internalDTO.ProductDescription()
            {
                Id = productDescription.Id,
                DescriptionId = productDescription.DescriptionId,
                Description = DescriptionMapper.MapFromBLL(productDescription.Description),
                ProductId = productDescription.ProductId,
                Product = ProductMapper.MapFromBLL(productDescription.Product)
            };
            return res;
        }
    }
}