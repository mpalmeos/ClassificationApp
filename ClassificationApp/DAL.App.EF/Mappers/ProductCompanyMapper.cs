using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductCompanyMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.ProductCompany))
            {
                // map internal to external
                return MapFromDomain((internalDTO.ProductCompany) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.ProductCompany))
            {
                // map external to internal
                return MapFromDAL((externalDTO.ProductCompany) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.ProductCompany MapFromDomain(internalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new externalDTO.ProductCompany()
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromDomain(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromDomain(productCompany.Company)
            };
            return res;
        }
        
        public static internalDTO.ProductCompany MapFromDAL(externalDTO.ProductCompany productCompany)
        {
            var res = productCompany == null ? null : new internalDTO.ProductCompany
            {
                Id = productCompany.Id,
                ProductId = productCompany.ProductId,
                Product = ProductMapper.MapFromDAL(productCompany.Product),
                CompanyId = productCompany.CompanyId,
                Company = CompanyMapper.MapFromDAL(productCompany.Company)
            };
            return res;
        }
    }
}