import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICompositionHerb} from "../../interfaces/app-interfaces/ICompositionHerb";
import {CompositionHerbService} from "../../services/app-services/composition-herb-service";

export var log = LogManager.getLogger('CompositionHerb.Details');

@autoinject
export class Details {

  private compositionHerb: ICompositionHerb | null = null;

  constructor(
    private router: Router,
    private compositionHerbService: CompositionHerbService
  ) {
    log.debug('constructor');
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
    this.compositionHerbService.fetch(params.id).then(
      compositionHerb => {
        log.debug('compositionHerb', compositionHerb);
        this.compositionHerb = compositionHerb;
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
