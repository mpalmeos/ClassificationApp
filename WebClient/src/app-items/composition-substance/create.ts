import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompositionSubstance} from "../../interfaces/app-interfaces/ICompositionSubstance";
import {CompositionSubstanceService} from "../../services/app-services/composition-substance-service";

export var log = LogManager.getLogger("CompositionSubstance.Create");

@autoinject
export class Create {

  private compositionSubstance: ICompositionSubstance;
  
  constructor(
    private router: Router,
    private compositionSubstanceService: CompositionSubstanceService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('compositionSubstance', this.compositionSubstance);
    this.compositionSubstanceService.post(this.compositionSubstance).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("compositionSubstanceIndex");
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

}
