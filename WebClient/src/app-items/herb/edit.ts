import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHerb} from "../../interfaces/app-interfaces/IHerb";
import {HerbService} from "../../services/app-services/herb-service";

export var log = LogManager.getLogger('Herb.Edit');

@autoinject
export class Edit {

  private herb : IHerb | null = null;

  constructor(
    private router: Router,
    private herbService: HerbService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herb', this.herb);
    this.herbService.put(this.herb!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.herbService.fetch(params.id).then(
      herb => {
        log.debug('herb', herb);
        this.herb = herb;
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
