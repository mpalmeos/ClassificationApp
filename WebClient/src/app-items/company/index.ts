import {LogManager, autoinject, View} from "aurelia-framework";
import {RouterConfiguration, Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";
import {CompanyService} from "services/app-services/company-service";


export var log = LogManager.getLogger("app.Comapnies.Index");

@autoinject
export class Companies {

  private companies : ICompany[] = [];
  
  constructor(private companyService: CompanyService){
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

    this.companyService.fetchAll().then(
      jsonData => {
        this.companies = jsonData;
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
