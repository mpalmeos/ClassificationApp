import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompositionHerb} from "../../interfaces/app-interfaces/ICompositionHerb";
import {CompositionHerbService} from "../../services/app-services/composition-herb-service";

export var log = LogManager.getLogger("CompositionHerb.Create");

@autoinject
export class Create {

  private compositionHerb: ICompositionHerb;
  
  constructor(
    private router: Router,
    private compositionHerbService: CompositionHerbService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('compositionHerb', this.compositionHerb);
    this.compositionHerbService.post(this.compositionHerb).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("compositionHerbIndex");
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
