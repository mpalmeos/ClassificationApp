import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";
import {ProductClassificationService} from "../../services/app-services/product-classification-service";

export var log = LogManager.getLogger("ProductClassifications.Index");

@autoinject
export class Index {

  private productClassifications : IProductClassification[] = [];
  
  constructor(private productClassificationService: ProductClassificationService){
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

    this.productClassificationService.fetchAll().then(
      jsonData => {
        this.productClassifications = jsonData;
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
