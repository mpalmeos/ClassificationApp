using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class CRoleMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CRole))
            {
                // map internal to external
                return MapFromBLL((internalDTO.CRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CRole))
            {
                // map external to internal
                return MapFromExternal((externalDTO.CRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CRole MapFromBLL(internalDTO.CRole cRole)
        {
            var res = cRole == null ? null : new externalDTO.CRole()
            {
                Id = cRole.Id,
                RoleValue = cRole.RoleValue
            };
            return res;
        }
        
        public static internalDTO.CRole MapFromExternal(externalDTO.CRole cRole)
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