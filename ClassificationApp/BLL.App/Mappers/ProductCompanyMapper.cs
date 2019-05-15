using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductCompanyMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductCompany))
            {
                // map internal to external
                return MapFromDAL((internalDTO.ProductCompany) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductCompany))
            {
                // map external to internal
                return MapFromBLL((externalDTO.ProductCompany) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductCompany MapFromDAL(internalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new externalDTO.ProductCompany()
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromDAL(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromDAL(productCompany.Company)
            };
            return res;
        }
        
        public static internalDTO.ProductCompany MapFromBLL(externalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new internalDTO.ProductCompany
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromBLL(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromBLL(productCompany.Company)
            };
            return res;
        }
    }
}