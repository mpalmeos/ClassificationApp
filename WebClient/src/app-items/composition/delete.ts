import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IComposition} from "../../interfaces/app-interfaces/IComposition";
import {CompositionService} from "../../services/app-services/composition-service";

export var log = LogManager.getLogger('Composition.Delete');

@autoinject
export class Delete {

  private composition: IComposition;

  constructor(
    private router: Router,
    private compositionService: CompositionService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.compositionService.delete(this.composition.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("compositionIndex");
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
    this.compositionService.fetch(params.id).then(
      composition => {
        log.debug('composition', composition);
        this.composition = composition;
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
