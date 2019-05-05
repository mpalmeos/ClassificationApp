using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class CompanyMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Company))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Company) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Company))
            {
                // map external to internal
                return MapFromExternal((externalDTO.Company) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Company MapFromBLL(internalDTO.Company company)
        {
            var res = company == null ? null : new externalDTO.Company()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            };
            return res;
        }
        
        public static internalDTO.Company MapFromExternal(externalDTO.Company company)
        {
            var res = company == null ? null : new internalDTO.Company
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            };
            return res;
        }
    }
}