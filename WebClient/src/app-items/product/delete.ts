import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProduct} from "../../interfaces/app-interfaces/IProduct";
import {ProductService} from "../../services/app-services/product-service";

export var log = LogManager.getLogger('Product.Delete');

@autoinject
export class Delete {

  private product: IProduct;

  constructor(
    private router: Router,
    private productService: ProductService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.productService.delete(this.product.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("productIndex");
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
    this.productService.fetch(params.id).then(
      product => {
        log.debug('product', product);
        this.product = product;
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