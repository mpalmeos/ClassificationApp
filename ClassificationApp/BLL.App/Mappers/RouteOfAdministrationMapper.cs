using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class RouteOfAdministrationMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.RouteOfAdministration))
            {
                // map internal to external
                return MapFromDAL((internalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.RouteOfAdministration))
            {
                // map external to internal
                return MapFromBLL((externalDTO.RouteOfAdministration) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.RouteOfAdministration MapFromDAL(internalDTO.RouteOfAdministration routeOfAdministration)
        {
            var res = routeOfAdministration == null ? null : new externalDTO.RouteOfAdministration()
            {
                Id = routeOfAdministration.Id,
                RouteOfAdministrationValue = routeOfAdministration.RouteOfAdministrationValue
            };
            return res;
        }
        
        public static internalDTO.RouteOfAdministration MapFromBLL(externalDTO.RouteOfAdministration routeOfAdministration)
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