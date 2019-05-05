using System;
using Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Product))
            {
                // map internal to external
                return MapFromDomain((internalDTO.Product) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Product))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Product) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Product MapFromDomain(internalDTO.Product product)
        {
            var res = product == null ? null : new externalDTO.Product()
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDomain(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromDomain(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromDomain(product.ProductName)
                
            };
            return res;
        }
        
        public static internalDTO.Product MapFromDAL(externalDTO.Product product)
        {
            var res = product == null ? null : new internalDTO.Product
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDAL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromDAL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromDAL(product.ProductName)
            };
            return res;
        }
    }
}