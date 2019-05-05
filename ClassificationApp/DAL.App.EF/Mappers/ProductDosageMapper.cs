using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductDosageMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDosage))
            {
                // map internal to external
                return MapFromDomain((internalDTO.ProductDosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDosage))
            {
                // map external to internal
                return MapFromDAL((externalDTO.ProductDosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDosage MapFromDomain(internalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new externalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromDomain(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromDomain(productDosage.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDosage MapFromDAL(externalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new internalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromDAL(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromDAL(productDosage.Product)
            };
            return res;
        }
    }
}