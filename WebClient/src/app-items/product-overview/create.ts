import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";
import {ProductCompanyService} from "../../services/app-services/product-company-service";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";
import {CompanyService} from "../../services/app-services/company-service";
import {RouteOfAdministrationService} from "../../services/app-services/route-of-administration-service";
import {ProductClassificationService} from "../../services/app-services/product-classification-service";
import {IProductName} from "../../interfaces/app-interfaces/IProductName";
import {IProduct} from "../../interfaces/app-interfaces/IProduct";
import {ProductService} from "../../services/app-services/product-service";
import {ProductNameService} from "../../services/app-services/product-name-service";

export var log = LogManager.getLogger("ProductCompany.Create");

@autoinject
export class Create {

  private newProductCompany: IProductCompany = new class implements IProductCompany {
    company: ICompany;
    id: number;
    product: IProduct;
  };
  private newProductName: IProductName = new class implements IProductName {
    id: number;
    productNameValue: string;
  };
  private newProduct: IProduct = new class implements IProduct {
    id: number;
    productClassification: IProductClassification;
    productName: IProductName;
    routeOfAdministration: IRouteOfAdministration;
  };
  private productDescription: IProductDescription;
  private company : ICompany[];
  private routeOfAdmin: IRouteOfAdministration[];
  private classification: IProductClassification[];
  
  constructor(
    private router: Router,
    private productCompanyService: ProductCompanyService,
    private productDescriptionService: ProductDescriptionService,
    private companyService: CompanyService,
    private routeOfAdminService: RouteOfAdministrationService,
    private classificationService: ProductClassificationService,
    private productService: ProductService,
    private productNameService: ProductNameService
  ){
    log.debug('constructor running');
  }
  
  // ============ View methods ==============
  submit():void{
    
    if (this.newProductName.productNameValue != null){
      this.productNameService.post(this.newProductName).then(
        response => {
          return response.json()}
      ).then(jsonData => {
        return <IProductName>jsonData;
      }).then(data => {
          this.newProduct.productName = data;
          return this.newProduct;
        }
      ).then(product => {
        this.productService.post(product).then(
          response => {return response.json()}
        ).then(jsonData => {return <IProduct>jsonData})
          .then(productData => {
            this.newProductCompany.product = productData;
            return this.newProductCompany;
          }).then(result => {
          this.productCompanyService.post(result).then(
            response => {
              if (response.status == 201){
                this.router.navigateToRoute("product-overviewIndex");
              } else {
                log.error('Error in response!', response)
              }
            }
          )
        })
      });
    } 
    
    /*this.newName.productNameValue = this.newProductName;
    this.newProduct.routeOfAdministration.id = this.newRouteOfAdminId;
    this.newProduct.productClassification.id = this.newClassificationId;
    this.productCompany.company.id = this.newCompanyId;
    this.productCompany.company.id = this.newCompanyId;
    this.newProduct.routeOfAdministration.id = this.newRouteOfAdminId;
    this.newProduct.productName.productNameValue = this.newProductName;
    this.newProduct.productClassification.id = this.newClassificationId;
    */
    /*
    this.productNameService.post(this.newName).then(
      response => response.json()
    ).then(data =>{
      this.newProduct.productName.id = data.fields.id;
      this.productService.post(this.newProduct).then(
        resp => resp.json()
      ).then(dat =>{
        this.productCompany.product.id = dat.id;
        this.productCompanyService.post(this.productCompany).then(
          r => {
            if (r.status == 201){
              this.router.navigateToRoute("product-overviewIndex");
            } else {
              log.error('Error in response!', r)
            }
          }
        )
      })
    });
    */
    /*    
        log.debug('productCompany', this.productCompany);
        this.productCompanyService.post(this.productCompany).then(
          response => {
            if (response.status == 201){
              this.router.navigateToRoute("product-overviewIndex");
            } else {
              log.error('Error in response!', response
            }
          }
        );
      */
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
    this.companyService.fetchAll().then(
      company => {
        log.debug('company', company);
        this.company = company;
      }
    );

    this.routeOfAdminService.fetchAll().then(
      routeOfAdmin => {
        log.debug('routeOfAdmin', routeOfAdmin);
        this.routeOfAdmin = routeOfAdmin;
      }
    );

    this.classificationService.fetchAll().then(
      classification => {
        log.debug('classification', classification);
        this.classification = classification;
      }
    );
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

}
