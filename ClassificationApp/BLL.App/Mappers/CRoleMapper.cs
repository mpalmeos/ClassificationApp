using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class CRoleMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.CRole))
            {
                // map internal to external
                return MapFromDAL((internalDTO.CRole) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.CRole))
            {
                // map external to internal
                return MapFromBLL((externalDTO.CRole) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.CRole MapFromDAL(internalDTO.CRole cRole)
        {
            var res = cRole == null ? null : new externalDTO.CRole()
            {
                Id = cRole.Id,
                RoleValue = cRole.RoleValue
            };
            return res;
        }
        
        public static internalDTO.CRole MapFromBLL(externalDTO.CRole cRole)
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