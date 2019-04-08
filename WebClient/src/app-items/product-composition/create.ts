import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductComposition} from "../../interfaces/app-interfaces/IProductComposition";
import {ProductCompositionService} from "../../services/app-services/product-composition-service";

export var log = LogManager.getLogger("ProductComposition.Create");

@autoinject
export class Create {

  private productComposition: IProductComposition;
  
  constructor(
    private router: Router,
    private productCompositionService: ProductCompositionService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productComposition', this.productComposition);
    this.productCompositionService.post(this.productComposition).then(
      response => {
        if (response.status == 201){
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

}
