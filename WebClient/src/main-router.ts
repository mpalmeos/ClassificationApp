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

      {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: true, title: 'Login'},
      {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: true, title: 'Register'},
      {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: true, title: 'Logout'},
      
      //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
      {route: ['companies', 'companies/index'], name: 'companies' + 'Index', moduleId: PLATFORM.moduleName('app-items/companies/index'), nav: true, title: 'Companies'},
      {route: 'companies/create', name: 'companies' + 'Create', moduleId: PLATFORM.moduleName('app-items/companies/create'), nav: true},
      
      /*
      {route: ['persons','persons/index'], name: 'persons' + 'Index', moduleId: PLATFORM.moduleName('persons/index'), nav: true, title: 'Persons'},
        {route: 'persons/create', name: 'persons' + 'Create', moduleId: PLATFORM.moduleName('persons/create'), nav: false, title: 'Persons Create'},
        {route: 'persons/edit/:id', name: 'persons' + 'Edit', moduleId: PLATFORM.moduleName('persons/edit'), nav: false, title: 'Persons Edit'},
        {route: 'persons/delete/:id', name: 'persons' + 'Delete', moduleId: PLATFORM.moduleName('persons/delete'), nav: false, title: 'Persons Delete'},
        {route: 'persons/details/:id', name: 'persons' + 'Details', moduleId: PLATFORM.moduleName('persons/details'), nav: false, title: 'Persons Details'},
      */ 
      
      
    ]);
  }
  
} 
