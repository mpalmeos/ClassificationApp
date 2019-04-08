import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";
import {RouteOfAdministrationService} from "../../services/app-services/route-of-administration-service";

export var log = LogManager.getLogger('RouteOfAdministration.Delete');

@autoinject
export class Delete {

  private routeOfAdministration: IRouteOfAdministration;

  constructor(
    private router: Router,
    private routeOfAdministrationService: RouteOfAdministrationService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.routeOfAdministrationService.delete(this.routeOfAdministration.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("routeOfAdministrationIndex");
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
    this.routeOfAdministrationService.fetch(params.id).then(
      routeOfAdministration => {
        log.debug('routeOfAdministration', routeOfAdministration);
        this.routeOfAdministration = routeOfAdministration;
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
