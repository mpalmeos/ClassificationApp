import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IDosage} from "../../interfaces/app-interfaces/IDosage";
import {DosageService} from "../../services/app-services/dosage-service";

export var log = LogManager.getLogger('Dosage.Edit');

@autoinject
export class Edit {

  private dosage : IDosage | null = null;

  constructor(
    private router: Router,
    private dosageService: DosageService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('dosage', this.dosage);
    this.dosageService.put(this.dosage!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("dosageIndex");
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

    this.dosageService.fetch(params.id).then(
      dosage => {
        log.debug('dosage', dosage);
        this.dosage = dosage;
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
