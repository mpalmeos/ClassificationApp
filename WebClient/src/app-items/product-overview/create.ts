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

export var log = LogManager.getLogger("ProductCompany.Create");

@autoinject
export class Create {

  private productCompany: IProductCompany;
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
    private classificationService: ProductClassificationService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productCompany', this.productCompany);
    this.productCompanyService.post(this.productCompany).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("product-overviewIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );

    log.debug('productDescription', this.productDescription);
    this.productDescriptionService.put(this.productDescription!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("product-overviewIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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
