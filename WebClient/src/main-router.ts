import {LogManager, autoinject, PLATFORM} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";

export var log = LogManager.getLogger("app.MainRouter");

@autoinject
export class MainRouter {
  
  private router: Router;
  
  constructor(){
    log.debug('constructor running');
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    log.debug('configureRouter running');
    
    this.router = router;
    config.title = 'Aurelia';
    config.map([
      {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},
      
      {route: ['companies', 'companies/index'], name: 'companies' + 'Index', moduleId: PLATFORM.moduleName('companies/index'), nav: true, title: 'Companies'},
      {route: 'companies/create', name: 'companies' + 'Create', moduleId: PLATFORM.moduleName('companies/create'), nav: true},
    ]);
  }
  
} 
