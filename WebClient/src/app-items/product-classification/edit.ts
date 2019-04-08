import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";
import {ProductClassificationService} from "../../services/app-services/product-classification-service";

export var log = LogManager.getLogger('ProductClassification.Edit');

@autoinject
export class Edit {

  private productClassification : IProductClassification | null = null;

  constructor(
    private router: Router,
    private productClassificationService: ProductClassificationService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('productClassification', this.productClassification);
    this.productClassificationService.put(this.productClassification!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.productClassificationService.fetch(params.id).then(
      productClassification => {
        log.debug('productClassification', productClassification);
        this.productClassification = productClassification;
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
