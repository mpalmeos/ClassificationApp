import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductComposition} from "../../interfaces/app-interfaces/IProductComposition";
import {ProductCompositionService} from "../../services/app-services/product-composition-service";

export var log = LogManager.getLogger('ProductComposition.Delete');

@autoinject
export class Delete {

  private productComposition: IProductComposition;

  constructor(
    private router: Router,
    private productCompositionService: ProductCompositionService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.productCompositionService.delete(this.productComposition.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("productCompositionIndex");
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
    this.productCompositionService.fetch(params.id).then(
      productComposition => {
        log.debug('productComposition', productComposition);
        this.productComposition = productComposition;
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
