import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IComposition} from "../../interfaces/app-interfaces/IComposition";
import {CompositionService} from "../../services/app-services/composition-service";

export var log = LogManager.getLogger('Composition.Edit');

@autoinject
export class Edit {

  private composition : IComposition | null = null;

  constructor(
    private router: Router,
    private compositionService: CompositionService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('composition', this.composition);
    this.compositionService.put(this.composition!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("compositionIndex");
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
