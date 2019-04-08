import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHerb} from "../../interfaces/app-interfaces/IHerb";
import {HerbService} from "../../services/app-services/herb-service";

export var log = LogManager.getLogger('Herb.Delete');

@autoinject
export class Delete {

  private herb: IHerb;

  constructor(
    private router: Router,
    private herbService: HerbService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.herbService.delete(this.herb.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("herbIndex");
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
