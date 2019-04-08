import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHerbPart} from "../../interfaces/app-interfaces/IHerbPart";
import {HerbPartService} from "../../services/app-services/herb-part-service";

export var log = LogManager.getLogger('HerbPart.Edit');

@autoinject
export class Edit {

  private herbPart : IHerbPart | null = null;

  constructor(
    private router: Router,
    private herbPartService: HerbPartService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbPart', this.herbPart);
    this.herbPartService.put(this.herbPart!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.herbPartService.fetch(params.id).then(
      herbPart => {
        log.debug('herbPart', herbPart);
        this.herbPart = herbPart;
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
