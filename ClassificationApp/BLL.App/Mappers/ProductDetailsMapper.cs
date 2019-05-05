using System;
using Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductDetailsMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductDetails))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Customs.ProductDetails) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Customs.ProductDetails))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Customs.ProductDetails) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductDetails MapFromDAL(internalDTO.Customs.ProductDetails product)
        {
            var res = product == null ? null : new externalDTO.Customs.ProductDetails()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDAL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromDAL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromDAL(product.ProductName),
                ProductCompanyId = product.ProductCompanyId,
                ProductCompany = ProductCompanyMapper.MapFromDAL(product.ProductCompany),
                ProductDescriptionId = product.ProductDescriptionId,
                ProductDescription = ProductDescriptionMapper.MapFromDAL(product.ProductDescription),
                ProductDosageId = product.ProductDosageId,
                ProductDosage = ProductDosageMapper.MapFromDAL(product.ProductDosage)
            };
            return res;
        }
        
        public static internalDTO.Customs.ProductDetails MapFromBLL(externalDTO.Customs.ProductDetails product)
        {
            var res = product == null ? null : new internalDTO.Customs.ProductDetails()
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
    }
}