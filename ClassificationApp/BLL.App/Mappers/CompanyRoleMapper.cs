using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class CompanyRoleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CompanyRole))
            {
                // map internal to external
                return MapFromDAL((internalDTO.CompanyRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CompanyRole))
            {
                // map external to internal
                return MapFromBLL((externalDTO.CompanyRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CompanyRole MapFromDAL(internalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new externalDTO.CompanyRole()
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromDAL(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromDAL(companyRole.CRole)
            };
            return res;
        }
        
        public static internalDTO.CompanyRole MapFromBLL(externalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new internalDTO.CompanyRole
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromBLL(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromBLL(companyRole.CRole)
            };
            return res;
        }
    }
}