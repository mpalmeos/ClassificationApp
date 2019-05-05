using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class DescriptionMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Description))
            {
                // map internal to external
                return MapFromDomain((internalDTO.Description) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Description))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Description) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Description MapFromDomain(internalDTO.Description description)
        {
            var res = description == null ? null : new externalDTO.Description()
            {
                Id = description.Id,
                DescriptionValue = description.DescriptionValue
            };
            return res;
        }
        
        public static internalDTO.Description MapFromDAL(externalDTO.Description description)
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