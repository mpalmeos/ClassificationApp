using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductOverviewMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductOverview))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Customs.ProductOverview) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Customs.ProductOverview))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Customs.ProductOverview) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductOverview MapFromDAL(internalDTO.Customs.ProductOverview product)
        {
            var res = product == null ? null : new externalDTO.Customs.ProductOverview()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDAL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromDAL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromDAL(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromDAL(product.ProductCompany)
            };
            return res;
        }
        
        public static internalDTO.Customs.ProductOverview MapFromBLL(externalDTO.Customs.ProductOverview product)
        {
            var res = product == null ? null : new internalDTO.Customs.ProductOverview()
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
    }
}