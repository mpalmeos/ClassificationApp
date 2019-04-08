import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IPlantForm} from "../../interfaces/app-interfaces/IPlantForm";
import {PlantFormService} from "../../services/app-services/plant-form-service";

export var log = LogManager.getLogger('PlantForm.Edit');

@autoinject
export class Edit {

  private plantForm : IPlantForm | null = null;

  constructor(
    private router: Router,
    private plantFormService: PlantFormService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('plantForm', this.plantForm);
    this.plantFormService.put(this.plantForm!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.plantFormService.fetch(params.id).then(
      plantForm => {
        log.debug('plantForm', plantForm);
        this.plantForm = plantForm;
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
