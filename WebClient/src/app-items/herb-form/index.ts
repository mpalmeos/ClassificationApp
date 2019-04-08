import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerbForm} from "../../interfaces/app-interfaces/IHerbForm";
import {HerbFormService} from "../../services/app-services/herb-form-service";

export var log = LogManager.getLogger("HerbForms.Index");

@autoinject
export class Index {

  private herbForms : IHerbForm[] = [];
  
  constructor(private herbFormService: HerbFormService){
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

    this.herbFormService.fetchAll().then(
      jsonData => {
        this.herbForms = jsonData;
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
