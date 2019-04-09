import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompanyRole} from "../../interfaces/app-interfaces/ICompanyRole";
import {CompanyRoleService} from "../../services/app-services/company-role-service";

export var log = LogManager.getLogger("CompanyRole.Create");

@autoinject
export class Create {

  private companyRole: ICompanyRole;
  
  constructor(
    private router: Router,
    private companyRoleService: CompanyRoleService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('companyRole', this.companyRole);
    this.companyRoleService.post(this.companyRole).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("company-roleIndex");
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
