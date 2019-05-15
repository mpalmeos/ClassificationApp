using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class CompanyMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Company))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Company) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Company))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Company) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Company MapFromDAL(internalDTO.Company company)
        {
            var res = company == null ? null : new externalDTO.Company()
            {
                Id = company.Id,
                CompanyName = company.CompanyName,
                CompanyAddress = company.CompanyAddress
            };
            return res;
        }
        
        public static internalDTO.Company MapFromBLL(externalDTO.Company company)
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