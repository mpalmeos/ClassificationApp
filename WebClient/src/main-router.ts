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
    config.title = 'Ravimiameti määratlused';
    config.map([
      {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: false, title: 'Pealeht'},

      {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Logi sisse'},
      {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Registreeri'},
      {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logi välja'},
      
      //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
      
      {route: ['product-overview','product-overview/index'], name: 'product-overview' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-overview/index'), nav: true, title: 'Määratletud tooted'},
      {route: 'product-overview/edit/:id', name: 'product-overview' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-overview/edit'), nav: false, title: 'Muuda toode'},
      {route: 'product-overview/delete/:id', name: 'product-overview' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-overview/delete'), nav: false, title: 'Kustuta toode'},
      {route: 'product-overview/details/:id', name: 'product-overview' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-overview/details'), nav: false, title: 'Detailivaade'},
      {route: 'product-overview/create', name: 'product-overview' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-overview/create'), nav: false, title: 'Lisa toode'},
      
    ]);
  }
  
} 
