import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";

export var log = LogManager.getLogger("ProductDescription.Create");

@autoinject
export class Create {

  private productDescription: IProductDescription;
  
  constructor(
    private router: Router,
    private productDescriptionService: ProductDescriptionService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productDescription', this.productDescription);
    this.productDescriptionService.post(this.productDescription).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("productDescriptionIndex");
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
