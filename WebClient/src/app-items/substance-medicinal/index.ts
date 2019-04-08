import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ISubstanceMedicinal} from "../../interfaces/app-interfaces/ISubstanceMedicinal";
import {SubstanceMedicinalService} from "../../services/app-services/substance-medicinal-service";

export var log = LogManager.getLogger("SubstanceMedicinals.Index");

@autoinject
export class Index {

  private substanceMedicinals : ISubstanceMedicinal[] = [];
  
  constructor(private substanceMedicinalService: SubstanceMedicinalService){
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

    this.substanceMedicinalService.fetchAll().then(
      jsonData => {
        this.substanceMedicinals = jsonData;
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
