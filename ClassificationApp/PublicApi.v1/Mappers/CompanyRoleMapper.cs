using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class CompanyRoleMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CompanyRole))
            {
                // map internal to external
                return MapFromBLL((internalDTO.CompanyRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CompanyRole))
            {
                // map external to internal
                return MapFromExternal((externalDTO.CompanyRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CompanyRole MapFromBLL(internalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new externalDTO.CompanyRole()
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromBLL(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromBLL(companyRole.CRole)
            };
            return res;
        }
        
        public static internalDTO.CompanyRole MapFromExternal(externalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new internalDTO.CompanyRole
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromExternal(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromExternal(companyRole.CRole)
            };
            return res;
        }
    }
}