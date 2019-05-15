using System;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductOverviewMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductOverview))
            {
                // map internal to external
                return MapFromDomain((ValueTuple<internalDTO.RouteOfAdministration, 
                    internalDTO.ProductClassification,
                    internalDTO.ProductName,
                    internalDTO.ProductCompany>) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(ValueTuple
                    <internalDTO.RouteOfAdministration, 
                        internalDTO.ProductClassification,
                        internalDTO.ProductName,
                        internalDTO.ProductCompany>))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Customs.ProductOverview) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductOverview MapFromDomain((
            internalDTO.RouteOfAdministration, 
            internalDTO.ProductClassification,
            internalDTO.ProductName,
            internalDTO.ProductCompany
            ) product)
        {
            var res = new externalDTO.Customs.ProductOverview()
            {
                RouteOfAdministrationId = product.Item1.Id,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDomain(product.Item1),
                ProductClassificationId = product.Item2.Id,
                ProductClassification = ProductClassificationMapper.MapFromDomain(product.Item2),
                ProductNameId = product.Item3.Id,
                ProductName = ProductNameMapper.MapFromDomain(product.Item3),
                ProductCompanyId = product.Item4.Id,
                ProductCompany = ProductCompanyMapper.MapFromDomain(product.Item4)
            };
            return res;
        }
        
        public static ValueTuple<internalDTO.RouteOfAdministration, 
            internalDTO.ProductClassification,
            internalDTO.ProductName,
            internalDTO.ProductCompany> MapFromDAL(externalDTO.Customs.ProductOverview product)
        {
            var res = new ValueTuple<
                internalDTO.RouteOfAdministration,
                internalDTO.ProductClassification,
                internalDTO.ProductName,
                internalDTO.ProductCompany>()
            {
                Item1 = RouteOfAdministrationMapper.MapFromDAL(product.RouteOfAdministration),
                Item2 = ProductClassificationMapper.MapFromDAL(product.ProductClassification),
                Item3 = ProductNameMapper.MapFromDAL(product.ProductName),
                Item4 = ProductCompanyMapper.MapFromDAL(product.ProductCompany)
            };
            return res;
        }
    }
}