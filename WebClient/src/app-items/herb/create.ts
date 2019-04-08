import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerb} from "../../interfaces/app-interfaces/IHerb";
import {HerbService} from "../../services/app-services/herb-service";

export var log = LogManager.getLogger("Herb.Create");

@autoinject
export class Create {

  private herb: IHerb;
  
  constructor(
    private router: Router,
    private herbService: HerbService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herb', this.herb);
    this.herbService.post(this.herb).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("herbIndex");
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
