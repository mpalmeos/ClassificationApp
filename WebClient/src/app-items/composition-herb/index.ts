import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompositionHerb} from "../../interfaces/app-interfaces/ICompositionHerb";
import {CompositionHerbService} from "../../services/app-services/composition-herb-service";

export var log = LogManager.getLogger("CompositionHerbs.Index");

@autoinject
export class Index {

  private compositionHerbs : ICompositionHerb[] = [];
  
  constructor(private compositionHerbService: CompositionHerbService){
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

    this.compositionHerbService.fetchAll().then(
      jsonData => {
        this.compositionHerbs = jsonData;
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
