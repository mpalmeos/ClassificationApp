import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IMedicinalDose} from "../../interfaces/app-interfaces/IMedicinalDose";
import {MedicinalDoseService} from "../../services/app-services/medicinal-dose-service";

export var log = LogManager.getLogger('MedicinalDose.Delete');

@autoinject
export class Delete {

  private medicinalDose: IMedicinalDose;

  constructor(
    private router: Router,
    private medicinalDoseService: MedicinalDoseService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.medicinalDoseService.delete(this.medicinalDose.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("medicinalDoseIndex");
      } else {
        log.debug('response', response);
      }
    });
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
    this.medicinalDoseService.fetch(params.id).then(
      medicinalDose => {
        log.debug('medicinalDose', medicinalDose);
        this.medicinalDose = medicinalDose;
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
