import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICRole} from "../../interfaces/app-interfaces/ICRole";
import {CRoleService} from "../../services/app-services/c-role-service";

export var log = LogManager.getLogger('CRole.Edit');

@autoinject
export class Edit {

  private cRole : ICRole | null = null;

  constructor(
    private router: Router,
    private cRoleService: CRoleService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('CRole', this.cRole);
    this.cRoleService.put(this.cRole!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("c-roleIndex");
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

    this.cRoleService.fetch(params.id).then(
      cRole => {
        log.debug('CRole', cRole);
        this.cRole = cRole;
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
