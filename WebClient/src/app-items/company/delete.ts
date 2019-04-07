import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";
import {CompanyService} from "../../services/app-services/company-service";

export var log = LogManager.getLogger('Company.Delete');

@autoinject
export class Delete {

  private company: ICompany;

  constructor(
    private router: Router,
    private companyService: CompanyService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.companyService.delete(this.company.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("companyIndex");
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
    this.companyService.fetch(params.id).then(
      company => {
        log.debug('contactType', company);
        this.company = company;
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
