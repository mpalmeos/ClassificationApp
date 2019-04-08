import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ISubstance} from "../../interfaces/app-interfaces/ISubstance";
import {SubstanceService} from "../../services/app-services/substance-service";

export var log = LogManager.getLogger('Substance.Edit');

@autoinject
export class Edit {

  private substance : ISubstance | null = null;

  constructor(
    private router: Router,
    private substanceService: SubstanceService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('substance', this.substance);
    this.substanceService.put(this.substance!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("substanceIndex");
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

    this.substanceService.fetch(params.id).then(
      substance => {
        log.debug('substance', substance);
        this.substance = substance;
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
