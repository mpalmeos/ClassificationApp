using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class CRoleMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CRole))
            {
                // map internal to external
                return MapFromDomain((internalDTO.CRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CRole))
            {
                // map external to internal
                return MapFromDAL((externalDTO.CRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CRole MapFromDomain(internalDTO.CRole cRole)
        {
            var res = cRole == null ? null : new externalDTO.CRole()
            {
                Id = cRole.Id,
                RoleValue = cRole.RoleValue
            };
            return res;
        }
        
        public static internalDTO.CRole MapFromDAL(externalDTO.CRole cRole)
        {
            var res = cRole == null ? null : new internalDTO.CRole
            {
                Id = cRole.Id,
                RoleValue = cRole.RoleValue
            };
            return res;
        }
    }
}