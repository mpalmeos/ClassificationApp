import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPlantPart} from "../../interfaces/app-interfaces/IPlantPart";
import {PlantPartService} from "../../services/app-services/plant-part-service";

export var log = LogManager.getLogger("PlantPart.Create");

@autoinject
export class Create {

  private plantPart: IPlantPart;
  
  constructor(
    private router: Router,
    private plantPartService: PlantPartService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('plantPart', this.plantPart);
    this.plantPartService.post(this.plantPart).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("plantPartIndex");
        } else {
          log.error('Error in response!', response);
        }
      }
    );
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

}
