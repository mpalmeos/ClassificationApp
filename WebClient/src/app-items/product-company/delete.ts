import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";
import {ProductCompanyService} from "../../services/app-services/product-company-service";

export var log = LogManager.getLogger('ProductCompany.Delete');

@autoinject
export class Delete {

  private productCompany: IProductCompany;

  constructor(
    private router: Router,
    private productCompanyService: ProductCompanyService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.productCompanyService.delete(this.productCompany.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("productCompanyIndex");
      } else {
        log.debug('response', response);
      }
    });
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

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
