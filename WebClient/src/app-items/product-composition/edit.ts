import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductComposition} from "../../interfaces/app-interfaces/IProductComposition";
import {ProductCompositionService} from "../../services/app-services/product-composition-service";

export var log = LogManager.getLogger('ProductComposition.Edit');

@autoinject
export class Edit {

  private productComposition : IProductComposition | null = null;

  constructor(
    private router: Router,
    private productCompositionService: ProductCompositionService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productComposition', this.productComposition);
    this.productCompositionService.put(this.productComposition!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("productCompositionIndex");
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
