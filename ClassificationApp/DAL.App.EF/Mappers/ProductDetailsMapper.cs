using System;
using ee.itcollege.mpalmeos.Contracts.DAL.Base.Mappers;
using internalDTO = Domain;
using externalDTO = DAL.App.DTO;

namespace DAL.App.EF.Mappers
{
    public class ProductDetailsMapper : IBaseDALMapper
    {
        public TOutObject Map<TOutObject>(object inObject)
            where TOutObject : class
        {
            if (typeof(TOutObject) == typeof(externalDTO.Customs.ProductDetails))
            {
                // map internal to external
                return MapFromDomain((ValueTuple<internalDTO.RouteOfAdministration, 
                    internalDTO.ProductClassification,
                    internalDTO.ProductName,
                    internalDTO.ProductCompany,
                    internalDTO.ProductDescription,
                    internalDTO.ProductDosage>) inObject) as TOutObject;
            }

            if (typeof(TOutObject) == typeof(ValueTuple
                    <internalDTO.RouteOfAdministration, 
                    internalDTO.ProductClassification,
                    internalDTO.ProductName,
                    internalDTO.ProductCompany,
                    internalDTO.ProductDescription,
                    internalDTO.ProductDosage>))
            {
                // map external to internal
                return MapFromDAL((externalDTO.Customs.ProductDetails) inObject) as TOutObject;
            }

            throw new InvalidCastException($"No conversion from {inObject.GetType().FullName} to {typeof(TOutObject).FullName}");
        }

        public static externalDTO.Customs.ProductDetails MapFromDomain((
            internalDTO.RouteOfAdministration, 
            internalDTO.ProductClassification,
            internalDTO.ProductName,
            internalDTO.ProductCompany,
            internalDTO.ProductDescription,
            internalDTO.ProductDosage
            ) product)
        {
            var res = new externalDTO.Customs.ProductDetails()
            {
                RouteOfAdministrationId = product.Item1.Id,
                RouteOfAdministration = RouteOfAdministrationMapper.MapFromDomain(product.Item1),
                ProductClassificationId = product.Item2.Id,
                ProductClassification = ProductClassificationMapper.MapFromDomain(product.Item2),
                ProductNameId = product.Item3.Id,
                ProductName = ProductNameMapper.MapFromDomain(product.Item3),
                ProductCompanyId = product.Item4.Id,
                ProductCompany = ProductCompanyMapper.MapFromDomain(product.Item4),
                ProductDescriptionId = product.Item5.Id,
                ProductDescription = ProductDescriptionMapper.MapFromDomain(product.Item5),
                ProductDosageId = product.Item6.Id,
                ProductDosage = ProductDosageMapper.MapFromDomain(product.Item6)
            };
            return res;
        }
        
        public static (
            internalDTO.RouteOfAdministration route, 
            internalDTO.ProductClassification pclass,
            internalDTO.ProductName pname,
            internalDTO.ProductCompany pcomp,
            internalDTO.ProductDescription pdesc,
            internalDTO.ProductDosage pdose
            ) MapFromDAL(externalDTO.Customs.ProductDetails product)
        {
            var res = (
                    route: RouteOfAdministrationMapper.MapFromDAL(product.RouteOfAdministration),
                    pclass: ProductClassificationMapper.MapFromDAL(product.ProductClassification),
                    pname: ProductNameMapper.MapFromDAL(product.ProductName),
                    pcomp: ProductCompanyMapper.MapFromDAL(product.ProductCompany),
                    pdesc: ProductDescriptionMapper.MapFromDAL(product.ProductDescription),
                    pdose: ProductDosageMapper.MapFromDAL(product.ProductDosage)
                    );
            return res;
        }
    }
}