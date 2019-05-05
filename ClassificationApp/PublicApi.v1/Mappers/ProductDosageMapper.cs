using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductDosageMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDosage))
            {
                // map internal to external
                return MapFromBLL((internalDTO.ProductDosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDosage))
            {
                // map external to internal
                return MapFromExternal((externalDTO.ProductDosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDosage MapFromBLL(internalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new externalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromBLL(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromBLL(productDosage.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDosage MapFromExternal(externalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new internalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromExternal(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromExternal(productDosage.Product)
            };
            return res;
        }
    }
}