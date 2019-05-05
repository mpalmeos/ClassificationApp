using System;
using externalDTO = PublicApi.v1.DTO;
using internalDTO = BLL.App.DTO;

namespace PublicApi.v1.Mappers
{
    public class ProductDetailsMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductDetails))
            {
                // map internal to external
                return MapFromBLL((internalDTO.Customs.ProductDetails) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Customs.ProductDetails))
            {
                // map external to internal
                return MapFromExternal((externalDTO.Customs.ProductDetails) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductDetails MapFromBLL(internalDTO.Customs.ProductDetails product)
        {
            var res = product == null ? null : new externalDTO.Customs.ProductDetails()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromBLL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromBLL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromBLL(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromBLL(product.ProductCompany),
                ProductDescriptionId = product.ProductDescriptionId,
                ProductDescription = ProductDescriptionMapper.MapFromBLL(product.ProductDescription),
                ProductDosageId = product.ProductDosageId,
                ProductDosage = ProductDosageMapper.MapFromBLL(product.ProductDosage)
            };
            return res;
        }
        
        public static internalDTO.Customs.ProductDetails MapFromExternal(externalDTO.Customs.ProductDetails product)
        {
            var res = product == null ? null : new internalDTO.Customs.ProductDetails()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromExternal(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromExternal(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromExternal(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromExternal(product.ProductCompany),
                ProductDescriptionId = product.ProductDescriptionId,
                ProductDescription = ProductDescriptionMapper.MapFromExternal(product.ProductDescription),
                ProductDosageId = product.ProductDosageId,
                ProductDosage = ProductDosageMapper.MapFromExternal(product.ProductDosage)
            };
            return res;
        }
    }
}