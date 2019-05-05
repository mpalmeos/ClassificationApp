using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class DosageMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Dosage))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Dosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Dosage))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Dosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Dosage MapFromDAL(internalDTO.Dosage dosage)
        {
            var res = dosage == null ? null : new externalDTO.Dosage()
            {
                Id = dosage.Id,
                DosageValue = dosage.DosageValue
            };
            return res;
        }
        
        public static internalDTO.Dosage MapFromBLL(externalDTO.Dosage dosage)
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