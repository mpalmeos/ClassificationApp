using System;
using ee.itcollege.mpalmeos.Contracts.BLL.Base.Mappers;
using internalDTO = DAL.App.DTO;
using externalDTO = BLL.App.DTO;

namespace BLL.App.Mappers
{
    public class ProductMapper : IBaseBLLMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Product))
            {
                // map internal to external
                return MapFromDAL((internalDTO.Product) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(internalDTO.Product))
            {
                // map external to internal
                return MapFromBLL((externalDTO.Product) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Product MapFromDAL(internalDTO.Product product)
        {
            var res = product == null ? null : new externalDTO.Product()
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
        
        public static internalDTO.Product MapFromBLL(externalDTO.Product product)
        {
            var res = product == null ? null : new internalDTO.Product
            {
                Id = product.Id,
                RouteOfAdministrationId = product.RouteOfAdministrationId,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromBLL(product.RouteOfAdministration),
                ProductClassificationId = product.ProductClassificationId,
                ProductClassification = ProductClassificationMapper.MapFromBLL(product.ProductClassification),
                ProductNameId = product.ProductNameId,
                ProductName = ProductNameMapper.MapFromBLL(product.ProductName)
            };
            return res;
        }
    }
}