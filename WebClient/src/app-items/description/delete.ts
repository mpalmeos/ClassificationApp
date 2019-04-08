import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IDescription} from "../../interfaces/app-interfaces/IDescription";
import {DescriptionService} from "../../services/app-services/description-service";

export var log = LogManager.getLogger('Description.Delete');

@autoinject
export class Delete {

  private description: IDescription;

  constructor(
    private router: Router,
    private descriptionService: DescriptionService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.descriptionService.delete(this.description.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("descriptionIndex");
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
    this.descriptionService.fetch(params.id).then(
      description => {
        log.debug('description', description);
        this.description = description;
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