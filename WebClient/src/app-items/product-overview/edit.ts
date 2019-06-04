import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";
import {ProductCompanyService} from "../../services/app-services/product-company-service";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";
import {CompanyService} from "../../services/app-services/company-service";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";
import {RouteOfAdministrationService} from "../../services/app-services/route-of-administration-service";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";
import {ProductClassificationService} from "../../services/app-services/product-classification-service";

export var log = LogManager.getLogger('ProductCompany.Edit');

@autoinject
export class Edit {

  private productCompany : IProductCompany | null = null;
  private productDescription: IProductDescription | null = null;
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
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productCompany', this.productCompany);
    this.productCompanyService.put(this.productCompany!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.productCompanyService.fetch(params.id).then(
      productCompany => {
        log.debug('productCompany', productCompany);
        this.productCompany = productCompany;
      }
    );

    this.productDescriptionService.fetch(params.id).then(
      productDescription => {
        log.debug('productDescription', productDescription);
        this.productDescription = productDescription;
      }
    );

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
