import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPlantForm} from "../../interfaces/app-interfaces/IPlantForm";
import {PlantFormService} from "../../services/app-services/plant-form-service";

export var log = LogManager.getLogger("PlantForm.Create");

@autoinject
export class Create {

  private plantForm: IPlantForm;
  
  constructor(
    private router: Router,
    private plantFormService: PlantFormService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('plantForm', this.plantForm);
    this.plantFormService.post(this.plantForm).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("plantFormIndex");
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
