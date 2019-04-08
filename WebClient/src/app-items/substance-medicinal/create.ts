import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ISubstanceMedicinal} from "../../interfaces/app-interfaces/ISubstanceMedicinal";
import {SubstanceMedicinalService} from "../../services/app-services/substance-medicinal-service";

export var log = LogManager.getLogger("SubstanceMedicinal.Create");

@autoinject
export class Create {

  private substanceMedicinal: ISubstanceMedicinal;
  
  constructor(
    private router: Router,
    private substanceMedicinalService: SubstanceMedicinalService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('substanceMedicinal', this.substanceMedicinal);
    this.substanceMedicinalService.post(this.substanceMedicinal).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("substanceMedicinalIndex");
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
