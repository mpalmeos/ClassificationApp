using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class DosageMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Dosage))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Dosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Dosage))
            {
                // map external to internal
                return MapFromExternal((externalDTO.Dosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Dosage MapFromBLL(internalDTO.Dosage dosage)
        {
            var res = dosage == null ? null : new externalDTO.Dosage()
            {
                Id = dosage.Id,
                DosageValue = dosage.DosageValue
            };
            return res;
        }
        
        public static internalDTO.Dosage MapFromExternal(externalDTO.Dosage dosage)
        {
            var res = dosage == null ? null : new internalDTO.Dosage()
            {
                Id = dosage.Id,
                DosageValue = dosage.DosageValue
            };
            return res;
        }
    }
}