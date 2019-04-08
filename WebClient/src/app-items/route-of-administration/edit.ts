import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";
import {RouteOfAdministrationService} from "../../services/app-services/route-of-administration-service";

export var log = LogManager.getLogger('RouteOfAdministration.Edit');

@autoinject
export class Edit {

  private routeOfAdministration : IRouteOfAdministration | null = null;

  constructor(
    private router: Router,
    private routeOfAdministrationService: RouteOfAdministrationService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('routeOfAdministration', this.routeOfAdministration);
    this.routeOfAdministrationService.put(this.routeOfAdministration!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("routeOfAdministrationIndex");
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
