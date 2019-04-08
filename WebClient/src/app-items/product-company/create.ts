import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";
import {ProductCompanyService} from "../../services/app-services/product-company-service";

export var log = LogManager.getLogger("ProductCompany.Create");

@autoinject
export class Create {

  private productCompany: IProductCompany;
  
  constructor(
    private router: Router,
    private productCompanyService: ProductCompanyService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productCompany', this.productCompany);
    this.productCompanyService.post(this.productCompany).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("productCompanyIndex");
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
