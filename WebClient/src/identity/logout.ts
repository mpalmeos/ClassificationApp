import {LogManager, autoinject, View} from "aurelia-framework";
import {AppConfig} from "../app-config";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";

export var log = LogManager.getLogger("app.Logout.Index");

@autoinject
export class Logout {

  constructor(private router: Router,
              private appConfig: AppConfig
  ){
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
    this.appConfig.jwt = null;
    this.router.navigateToRoute('home');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
