import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";
import {ProductClassificationService} from "../../services/app-services/product-classification-service";

export var log = LogManager.getLogger("ProductClassification.Create");

@autoinject
export class Create {

  private productClassification: IProductClassification;
  
  constructor(
    private router: Router,
    private productClassificationService: ProductClassificationService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productClassification', this.productClassification);
    this.productClassificationService.post(this.productClassification).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("productClassificationIndex");
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
