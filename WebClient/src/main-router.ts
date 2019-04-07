import {LogManager, autoinject, PLATFORM} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import {AppConfig} from "./app-config";

export var log = LogManager.getLogger("app.MainRouter");

@autoinject
export class MainRouter {
  
  private router: Router;
  
  constructor(private appConfig: AppConfig){
    log.debug('constructor running');
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    log.debug('configureRouter running');
    
    this.router = router;
    config.title = 'WebClient - Aurelia';
    config.map([
      {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

      {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
      {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
      {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},
      
      //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
      {route: ['company','company/index'], name: 'company' + 'Index', moduleId: PLATFORM.moduleName('app-items/company/index'), nav: true, title: 'Company'},
      {route: 'company/create', name: 'company' + 'Create', moduleId: PLATFORM.moduleName('app-items/company/create'), nav: false, title: 'Company Create'},
      {route: 'company/edit/:id', name: 'company' + 'Edit', moduleId: PLATFORM.moduleName('app-items/company/edit'), nav: false, title: 'Company Edit'},
      {route: 'company/delete/:id', name: 'company' + 'Delete', moduleId: PLATFORM.moduleName('app-items/company/delete'), nav: false, title: 'Company Delete'},
      {route: 'company/details/:id', name: 'company' + 'Details', moduleId: PLATFORM.moduleName('app-items/company/details'), nav: false, title: 'Company Details'},
      
      
    ]);
  }
  
} 
