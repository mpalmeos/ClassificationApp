import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ISubstanceCategory} from "../../interfaces/app-interfaces/ISubstanceCategory";
import {SubstanceCategoryService} from "../../services/app-services/substance-category-service";

export var log = LogManager.getLogger("SubstanceCategorys.Index");

@autoinject
export class Index {

  private substanceCategorys : ISubstanceCategory[] = [];
  
  constructor(private substanceCategoryService: SubstanceCategoryService){
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

    this.substanceCategoryService.fetchAll().then(
      jsonData => {
        this.substanceCategorys = jsonData;
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
