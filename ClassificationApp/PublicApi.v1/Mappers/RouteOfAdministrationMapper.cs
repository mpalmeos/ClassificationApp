using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class RouteOfAdministrationMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.RouteOfAdministration))
            {
                // map internal to external
                return MapFromBLL((internalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.RouteOfAdministration))
            {
                // map external to internal
                return MapFromExternal((externalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.RouteOfAdministration MapFromBLL(internalDTO.RouteOfAdministration routeOfAdministration)
        {
            var res = routeOfAdministration == null ? null : new externalDTO.RouteOfAdministration()
            {
                Id = routeOfAdministration.Id,
                RouteOfAdministrationValue = routeOfAdministration.RouteOfAdministrationValue
            };
            return res;
        }
        
        public static internalDTO.RouteOfAdministration MapFromExternal(externalDTO.RouteOfAdministration routeOfAdministration)
        {
            var res = routeOfAdministration == null ? null : new internalDTO.RouteOfAdministration()
            {
                Id = routeOfAdministration.Id,
                RouteOfAdministrationValue = routeOfAdministration.RouteOfAdministrationValue
            };
            return res;
        }
    }
}