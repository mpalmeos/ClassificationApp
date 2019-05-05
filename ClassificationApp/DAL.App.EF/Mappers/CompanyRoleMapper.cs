using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class CompanyRoleMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CompanyRole))
            {
                // map internal to external
                return MapFromDomain((internalDTO.CompanyRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CompanyRole))
            {
                // map external to internal
                return MapFromDAL((externalDTO.CompanyRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CompanyRole MapFromDomain(internalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new externalDTO.CompanyRole()
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromDomain(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromDomain(companyRole.CRole)
            };
            return res;
        }
        
        public static internalDTO.CompanyRole MapFromDAL(externalDTO.CompanyRole companyRole)
        {
            var res = companyRole == null ? null : new internalDTO.CompanyRole
            {
                Id = companyRole.Id,
                CompanyId = companyRole.CompanyId,
                Company = CompanyMapper.MapFromDAL(companyRole.Company),
                CRoleId = companyRole.CRoleId,
                CRole = CRoleMapper.MapFromDAL(companyRole.CRole)
            };
            return res;
        }
    }
}