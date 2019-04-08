import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";
import {RouteOfAdministrationService} from "../../services/app-services/route-of-administration-service";

export var log = LogManager.getLogger("RouteOfAdministrations.Index");

@autoinject
export class Index {

  private routeOfAdministrations : IRouteOfAdministration[] = [];
  
  constructor(private routeOfAdministrationService: RouteOfAdministrationService){
    log.debug('constructor running');
  }

  created(owningView: View, myView: View){
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }

  attached(){
    log.debug('attached');

    this.routeOfAdministrationService.fetchAll().then(
      jsonData => {
        this.routeOfAdministrations = jsonData;
      }
    );
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
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
