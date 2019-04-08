import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICompanyRole} from "../../interfaces/app-interfaces/ICompanyRole";
import {CompanyRoleService} from "../../services/app-services/company-role-service";

export var log = LogManager.getLogger('CompanyRole.Edit');

@autoinject
export class Edit {

  private companyRole : ICompanyRole | null = null;

  constructor(
    private router: Router,
    private companyRoleService: CompanyRoleService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('companyRole', this.companyRole);
    this.companyRoleService.put(this.companyRole!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("companyRoleIndex");
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

    this.companyRoleService.fetch(params.id).then(
      companyRole => {
        log.debug('companyRole', companyRole);
        this.companyRole = companyRole;
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
