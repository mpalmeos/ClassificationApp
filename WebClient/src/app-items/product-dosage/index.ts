import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IProductDosage} from "../../interfaces/app-interfaces/IProductDosage";
import {ProductDosageService} from "../../services/app-services/product-dosage-service";

export var log = LogManager.getLogger("ProductDosages.Index");

@autoinject
export class Index {

  private productDosages : IProductDosage[] = [];
  
  constructor(private productDosageService: ProductDosageService){
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

    this.productDosageService.fetchAll().then(
      jsonData => {
        this.productDosages = jsonData;
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
