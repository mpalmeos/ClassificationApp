using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class RouteOfAdministrationMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.RouteOfAdministration))
            {
                // map internal to external
                return MapFromDomain((internalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.RouteOfAdministration))
            {
                // map external to internal
                return MapFromDAL((externalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.RouteOfAdministration MapFromDomain(internalDTO.RouteOfAdministration routeOfAdministration)
        {
            var res = routeOfAdministration == null ? null : new externalDTO.RouteOfAdministration()
            {
                Id = routeOfAdministration.Id,
                RouteOfAdministrationValue = routeOfAdministration.RouteOfAdministrationValue
            };
            return res;
        }
        
        public static internalDTO.RouteOfAdministration MapFromDAL(externalDTO.RouteOfAdministration routeOfAdministration)
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