import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";
import {ProductCompanyService} from "../../services/app-services/product-company-service";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";

export var log = LogManager.getLogger('ProductCompany.Details');

@autoinject
export class Details {

  private productCompany: IProductCompany | null = null;
  private productDescription: IProductDescription | null = null;

  constructor(
    private router: Router,
    private productCompanyService: ProductCompanyService,
    private productDescriptionService: ProductDescriptionService
  ) {
    log.debug('constructor');
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

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
