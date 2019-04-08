import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IPlantPart} from "../../interfaces/app-interfaces/IPlantPart";
import {PlantPartService} from "../../services/app-services/plant-part-service";

export var log = LogManager.getLogger('PlantPart.Details');

@autoinject
export class Details {

  private plantPart: IPlantPart | null = null;

  constructor(
    private router: Router,
    private plantPartService: PlantPartService
  ) {
    log.debug('constructor');
  }

  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate', params);
    this.plantPartService.fetch(params.id).then(
      plantPart => {
        log.debug('plantPart', plantPart);
        this.plantPart = plantPart;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
