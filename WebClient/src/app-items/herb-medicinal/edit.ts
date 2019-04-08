import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHerbMedicinal} from "../../interfaces/app-interfaces/IHerbMedicinal";
import {HerbMedicinalService} from "../../services/app-services/herb-medicinal-service";

export var log = LogManager.getLogger('HerbMedicinal.Edit');

@autoinject
export class Edit {

  private herbMedicinal : IHerbMedicinal | null = null;

  constructor(
    private router: Router,
    private herbMedicinalService: HerbMedicinalService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbMedicinal', this.herbMedicinal);
    this.herbMedicinalService.put(this.herbMedicinal!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.herbMedicinalService.fetch(params.id).then(
      herbMedicinal => {
        log.debug('herbMedicinal', herbMedicinal);
        this.herbMedicinal = herbMedicinal;
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
