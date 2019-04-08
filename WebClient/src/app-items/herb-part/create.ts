import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerbPart} from "../../interfaces/app-interfaces/IHerbPart";
import {HerbPartService} from "../../services/app-services/herb-part-service";

export var log = LogManager.getLogger("HerbPart.Create");

@autoinject
export class Create {

  private herbPart: IHerbPart;
  
  constructor(
    private router: Router,
    private herbPartService: HerbPartService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbPart', this.herbPart);
    this.herbPartService.post(this.herbPart).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("herbPartIndex");
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
