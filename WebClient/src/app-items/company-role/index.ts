import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompanyRole} from "../../interfaces/app-interfaces/ICompanyRole";
import {CompanyRoleService} from "../../services/app-services/company-role-service";

export var log = LogManager.getLogger("CompanyRoles.Index");

@autoinject
export class Index {

  private companyRoles : ICompanyRole[] = [];
  
  constructor(private companyRoleService: CompanyRoleService){
    log.debug('constructor running');
  }

  created(owningView: View, myView: View){
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }

  attached(){
    log.debug('attached');

    this.companyRoleService.fetchAll().then(
      jsonData => {
        this.companyRoles = jsonData;
      }
    );
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
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
