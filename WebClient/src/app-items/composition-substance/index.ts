import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompositionSubstance} from "../../interfaces/app-interfaces/ICompositionSubstance";
import {CompositionSubstanceService} from "../../services/app-services/composition-substance-service";

export var log = LogManager.getLogger("CompositionSubstances.Index");

@autoinject
export class Index {

  private compositionSubstances : ICompositionSubstance[] = [];
  
  constructor(private compositionSubstanceService: CompositionSubstanceService){
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

    this.compositionSubstanceService.fetchAll().then(
      jsonData => {
        this.compositionSubstances = jsonData;
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
