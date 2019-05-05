using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class DescriptionMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Description))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Description) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Description))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Description) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Description MapFromDAL(internalDTO.Description description)
        {
            var res = description == null ? null : new externalDTO.Description()
            {
                Id = description.Id,
                DescriptionValue = description.DescriptionValue
            };
            return res;
        }
        
        public static internalDTO.Description MapFromBLL(externalDTO.Description description)
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