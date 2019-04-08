import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IMedicinalDose} from "../../interfaces/app-interfaces/IMedicinalDose";
import {MedicinalDoseService} from "../../services/app-services/medicinal-dose-service";

export var log = LogManager.getLogger("MedicinalDose.Create");

@autoinject
export class Create {

  private medicinalDose: IMedicinalDose;
  
  constructor(
    private router: Router,
    private medicinalDoseService: MedicinalDoseService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('medicinalDose', this.medicinalDose);
    this.medicinalDoseService.post(this.medicinalDose).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("medicinalDoseIndex");
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
