import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductName} from "../../interfaces/app-interfaces/IProductName";
import {ProductNameService} from "../../services/app-services/product-name-service";

export var log = LogManager.getLogger("ProductName.Create");

@autoinject
export class Create {

  private productNameC: IProductName;
  
  constructor(
    private router: Router,
    private productNameService: ProductNameService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productName', this.productNameC);
    this.productNameService.post(this.productNameC).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("productNameIndex");
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
