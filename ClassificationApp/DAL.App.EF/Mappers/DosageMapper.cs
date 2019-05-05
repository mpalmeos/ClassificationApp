using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class DosageMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Dosage))
            {
                // map internal to external
                return MapFromDomain((internalDTO.Dosage) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Dosage))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Dosage) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }


        public static externalDTO.Dosage MapFromDomain(internalDTO.Dosage dosage)
        {
            var res = dosage == null ? null : new externalDTO.Dosage()
            {
                Id = dosage.Id,
                DosageValue = dosage.DosageValue
            };
            return res;
        }
        
        public static internalDTO.Dosage MapFromDAL(externalDTO.Dosage dosage)
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