import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductDosage} from "../../interfaces/app-interfaces/IProductDosage";
import {ProductDosageService} from "../../services/app-services/product-dosage-service";

export var log = LogManager.getLogger('ProductDosage.Details');

@autoinject
export class Details {

  private productDosage: IProductDosage | null = null;

  constructor(
    private router: Router,
    private productDosageService: ProductDosageService
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
    this.productDosageService.fetch(params.id).then(
      productDosage => {
        log.debug('productDosage', productDosage);
        this.productDosage = productDosage;
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