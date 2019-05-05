using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductCompanyMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductCompany))
            {
                // map internal to external
                return MapFromBLL((internalDTO.ProductCompany) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductCompany))
            {
                // map external to internal
                return MapFromExternal((externalDTO.ProductCompany) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductCompany MapFromBLL(internalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new externalDTO.ProductCompany()
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromBLL(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromBLL(productCompany.Company)
            };
            return res;
        }
        
        public static internalDTO.ProductCompany MapFromExternal(externalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new internalDTO.ProductCompany
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromExternal(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromExternal(productCompany.Company)
            };
            return res;
        }
    }
}