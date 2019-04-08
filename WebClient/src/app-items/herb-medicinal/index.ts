import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerbMedicinal} from "../../interfaces/app-interfaces/IHerbMedicinal";
import {HerbMedicinalService} from "../../services/app-services/herb-medicinal-service";

export var log = LogManager.getLogger("HerbMedicinals.Index");

@autoinject
export class Index {

  private herbMedicinals : IHerbMedicinal[] = [];
  
  constructor(private herbMedicinalService: HerbMedicinalService){
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

    this.herbMedicinalService.fetchAll().then(
      jsonData => {
        this.herbMedicinals = jsonData;
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
