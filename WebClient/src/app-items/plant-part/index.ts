import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPlantPart} from "../../interfaces/app-interfaces/IPlantPart";
import {PlantPartService} from "../../services/app-services/plant-part-service";

export var log = LogManager.getLogger("PlantParts.Index");

@autoinject
export class Index {

  private plantParts : IPlantPart[] = [];
  
  constructor(private plantPartService: PlantPartService){
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

    this.plantPartService.fetchAll().then(
      jsonData => {
        this.plantParts = jsonData;
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
