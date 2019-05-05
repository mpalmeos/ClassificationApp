using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductOverviewMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductOverview))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Customs.ProductOverview) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Customs.ProductOverview))
            {
                // map external to internal
                return MapFromExternal((externalDTO.Customs.ProductOverview) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductOverview MapFromBLL(internalDTO.Customs.ProductOverview product)
        {
            var res = product == null ? null : new externalDTO.Customs.ProductOverview()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromBLL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromBLL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromBLL(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromBLL(product.ProductCompany)
            };
            return res;
        }
        
        public static internalDTO.Customs.ProductOverview MapFromExternal(externalDTO.Customs.ProductOverview product)
        {
            var res = product == null ? null : new internalDTO.Customs.ProductOverview()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromExternal(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromExternal(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromExternal(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromExternal(product.ProductCompany)
            };
            return res;
        }
    }
}