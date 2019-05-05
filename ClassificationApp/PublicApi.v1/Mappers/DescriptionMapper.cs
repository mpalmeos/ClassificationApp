using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class DescriptionMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Description))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Description) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Description))
            {
                // map external to internal
                return MapFromExternal((externalDTO.Description) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Description MapFromBLL(internalDTO.Description description)
        {
            var res = description == null ? null : new externalDTO.Description()
            {
                Id = description.Id,
                DescriptionValue = description.DescriptionValue
            };
            return res;
        }
        
        public static internalDTO.Description MapFromExternal(externalDTO.Description description)
        {
            var res = description == null ? null : new internalDTO.Description()
            {
                Id = description.Id,
                DescriptionValue = description.DescriptionValue
            };
            return res;
        }
    }
}