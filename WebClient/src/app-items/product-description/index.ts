import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";
import {ProductDescriptionService} from "../../services/app-services/product-description-service";

export var log = LogManager.getLogger("ProductDescriptions.Index");

@autoinject
export class Index {

  private productDescriptions : IProductDescription[] = [];
  
  constructor(private productDescriptionService: ProductDescriptionService){
    log.debug('constructor running');
  }

  created(owningView: View, myView: View){
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }

  attached(){
    log.debug('attached');

    this.productDescriptionService.fetchAll().then(
      jsonData => {
        this.productDescriptions = jsonData;
      }
    );
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
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
