import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IMedicinalDose} from "../../interfaces/app-interfaces/IMedicinalDose";
import {MedicinalDoseService} from "../../services/app-services/medicinal-dose-service";

export var log = LogManager.getLogger("MedicinalDoses.Index");

@autoinject
export class Index {

  private medicinalDoses : IMedicinalDose[] = [];
  
  constructor(private medicinalDoseService: MedicinalDoseService){
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

    this.medicinalDoseService.fetchAll().then(
      jsonData => {
        this.medicinalDoses = jsonData;
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
