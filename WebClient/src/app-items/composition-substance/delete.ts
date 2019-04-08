import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICompositionSubstance} from "../../interfaces/app-interfaces/ICompositionSubstance";
import {CompositionSubstanceService} from "../../services/app-services/composition-substance-service";

export var log = LogManager.getLogger('CompositionSubstance.Delete');

@autoinject
export class Delete {

  private compositionSubstance: ICompositionSubstance;

  constructor(
    private router: Router,
    private compositionSubstanceService: CompositionSubstanceService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.compositionSubstanceService.delete(this.compositionSubstance.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("compositionSubstanceIndex");
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
    this.compositionSubstanceService.fetch(params.id).then(
      compositionSubstance => {
        log.debug('compositionSubstance', compositionSubstance);
        this.compositionSubstance = compositionSubstance;
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
