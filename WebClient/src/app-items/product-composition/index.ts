import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductComposition} from "../../interfaces/app-interfaces/IProductComposition";
import {ProductCompositionService} from "../../services/app-services/product-composition-service";

export var log = LogManager.getLogger("ProductCompositions.Index");

@autoinject
export class Index {

  private productCompositions : IProductComposition[] = [];
  
  constructor(private productCompositionService: ProductCompositionService){
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

    this.productCompositionService.fetchAll().then(
      jsonData => {
        this.productCompositions = jsonData;
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
