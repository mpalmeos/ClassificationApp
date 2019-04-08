import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductDosage} from "../../interfaces/app-interfaces/IProductDosage";
import {ProductDosageService} from "../../services/app-services/product-dosage-service";

export var log = LogManager.getLogger("ProductDosage.Create");

@autoinject
export class Create {

  private productDosage: IProductDosage;
  
  constructor(
    private router: Router,
    private productDosageService: ProductDosageService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productDosage', this.productDosage);
    this.productDosageService.post(this.productDosage).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("productDosageIndex");
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
