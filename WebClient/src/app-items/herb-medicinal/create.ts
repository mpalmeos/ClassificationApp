import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerbMedicinal} from "../../interfaces/app-interfaces/IHerbMedicinal";
import {HerbMedicinalService} from "../../services/app-services/herb-medicinal-service";

export var log = LogManager.getLogger("HerbMedicinal.Create");

@autoinject
export class Create {

  private herbMedicinal: IHerbMedicinal;
  
  constructor(
    private router: Router,
    private herbMedicinalService: HerbMedicinalService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbMedicinal', this.herbMedicinal);
    this.herbMedicinalService.post(this.herbMedicinal).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("herbMedicinalIndex");
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
