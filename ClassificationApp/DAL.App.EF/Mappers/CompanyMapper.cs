using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class CompanyMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Company))
            {
                // map internal to external
                return MapFromDomain((internalDTO.Company) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Company))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Company) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Company MapFromDomain(internalDTO.Company company)
        {
            var res = company == null ? null : new externalDTO.Company()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            };
            return res;
        }
        
        public static internalDTO.Company MapFromDAL(externalDTO.Company company)
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