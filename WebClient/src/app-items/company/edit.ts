import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";
import {CompanyService} from "../../services/app-services/company-service";

export var log = LogManager.getLogger('Company.Edit');

@autoinject
export class Edit {

  private company : ICompany | null = null;

  constructor(
    private router: Router,
    private companyService: CompanyService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('company', this.company);
    this.companyService.put(this.company!).then(
      response => {
        if (response.status == 204){
          this.router.navigateToRoute("companyIndex");
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

    this.companyService.fetch(params.id).then(
      company => {
        log.debug('company', company);
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
