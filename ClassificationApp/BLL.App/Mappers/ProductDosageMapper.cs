using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductDosageMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductDosage))
            {
                // map internal to external
                return MapFromDAL((internalDTO.ProductDosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductDosage))
            {
                // map external to internal
                return MapFromBLL((externalDTO.ProductDosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.ProductDosage MapFromDAL(internalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new externalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromDAL(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromDAL(productDosage.Product)
            };
            return res;
        }
        
        public static internalDTO.ProductDosage MapFromBLL(externalDTO.ProductDosage productDosage)
        {
            var res = productDosage == null ? null : new internalDTO.ProductDosage()
            {
                Id = productDosage.Id,
                DosageId = productDosage.DosageId,
                Dosage =  DosageMapper.MapFromBLL(productDosage.Dosage),
                ProductId = productDosage.ProductId,
                Product = ProductMapper.MapFromBLL(productDosage.Product)
            };
            return res;
        }
    }
}