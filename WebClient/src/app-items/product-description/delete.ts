import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";

export var log = LogManager.getLogger('ProductDescription.Delete');

@autoinject
export class Delete {

  private productDescription: IProductDescription;

  constructor(
    private router: Router,
    private productDescriptionService: ProductDescriptionService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.productDescriptionService.delete(this.productDescription.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("productDescriptionIndex");
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