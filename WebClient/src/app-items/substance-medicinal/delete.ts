import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ISubstanceMedicinal} from "../../interfaces/app-interfaces/ISubstanceMedicinal";
import {SubstanceMedicinalService} from "../../services/app-services/substance-medicinal-service";

export var log = LogManager.getLogger('SubstanceMedicinal.Delete');

@autoinject
export class Delete {

  private substanceMedicinal: ISubstanceMedicinal;

  constructor(
    private router: Router,
    private substanceMedicinalService: SubstanceMedicinalService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.substanceMedicinalService.delete(this.substanceMedicinal.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("substanceMedicinalIndex");
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
    this.substanceMedicinalService.fetch(params.id).then(
      substanceMedicinal => {
        log.debug('substanceMedicinal', substanceMedicinal);
        this.substanceMedicinal = substanceMedicinal;
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
