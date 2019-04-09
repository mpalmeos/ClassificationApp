import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductName} from "../../interfaces/app-interfaces/IProductName";
import {ProductNameService} from "../../services/app-services/product-name-service";

export var log = LogManager.getLogger('ProductName.Delete');

@autoinject
export class Delete {

  private productNameD: IProductName;

  constructor(
    private router: Router,
    private productNameService: ProductNameService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.productNameService.delete(this.productNameD.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("productNameIndex");
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
    this.productNameService.fetch(params.id).then(
      productName => {
        log.debug('productName', productName);
        this.productNameD = productName;
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
