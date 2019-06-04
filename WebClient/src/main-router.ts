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
      {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Pealeht'},

      {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Logi sisse'},
      {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Registreeri'},
      {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logi välja'},
      
      //{route: '', name: '', moduleId: PLATFORM.moduleName(''), nav: true, title: ''},
      
      {route: ['company','company/index'], name: 'company' + 'Index', moduleId: PLATFORM.moduleName('app-items/company/index'), nav: false, title: 'Company'},
      {route: 'company/create', name: 'company' + 'Create', moduleId: PLATFORM.moduleName('app-items/company/create'), nav: false, title: 'Company Create'},
      {route: 'company/edit/:id', name: 'company' + 'Edit', moduleId: PLATFORM.moduleName('app-items/company/edit'), nav: false, title: 'Company Edit'},
      {route: 'company/delete/:id', name: 'company' + 'Delete', moduleId: PLATFORM.moduleName('app-items/company/delete'), nav: false, title: 'Company Delete'},
      {route: 'company/details/:id', name: 'company' + 'Details', moduleId: PLATFORM.moduleName('app-items/company/details'), nav: false, title: 'Company Details'},

      {route: ['product-overview','product-overview/index'], name: 'product-overview' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-overview/index'), nav: true, title: 'Määratletud tooted'},
      {route: 'product-overview/edit/:id', name: 'product-overview' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-overview/edit'), nav: false, title: 'Muuda toode'},
      {route: 'product-overview/delete/:id', name: 'product-overview' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-overview/delete'), nav: false, title: 'Kustuta toode'},
      {route: 'product-overview/details/:id', name: 'product-overview' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-overview/details'), nav: false, title: 'Detailivaade'},
      {route: 'product-overview/create', name: 'product-overview' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-overview/create'), nav: false, title: 'Lisa toode'},
      
      /*
      {route: ['c-role','c-role/index'], name: 'c-role' + 'Index', moduleId: PLATFORM.moduleName('app-items/c-role/index'), nav: false, title: 'C-role'},
      {route: 'c-role/create', name: 'c-role' + 'Create', moduleId: PLATFORM.moduleName('app-items/c-role/create'), nav: false, title: 'C-role Create'},
      {route: 'c-role/edit/:id', name: 'c-role' + 'Edit', moduleId: PLATFORM.moduleName('app-items/c-role/edit'), nav: false, title: 'C-role Edit'},
      {route: 'c-role/delete/:id', name: 'c-role' + 'Delete', moduleId: PLATFORM.moduleName('app-items/c-role/delete'), nav: false, title: 'C-role Delete'},
      {route: 'c-role/details/:id', name: 'c-role' + 'Details', moduleId: PLATFORM.moduleName('app-items/c-role/details'), nav: false, title: 'C-role Details'},
      
      {route: ['company-role','company-role/index'], name: 'company-role' + 'Index', moduleId: PLATFORM.moduleName('app-items/company-role/index'), nav: false, title: 'Company-role'},
      {route: 'company-role/create', name: 'company-role' + 'Create', moduleId: PLATFORM.moduleName('app-items/company-role/create'), nav: false, title: 'Company-role Create'},
      {route: 'company-role/edit/:id', name: 'company-role' + 'Edit', moduleId: PLATFORM.moduleName('app-items/company-role/edit'), nav: false, title: 'Company-role Edit'},
      {route: 'company-role/delete/:id', name: 'company-role' + 'Delete', moduleId: PLATFORM.moduleName('app-items/company-role/delete'), nav: false, title: 'Company-role Delete'},
      {route: 'company-role/details/:id', name: 'company-role' + 'Details', moduleId: PLATFORM.moduleName('app-items/company-role/details'), nav: false, title: 'Company-role Details'},
      
      {route: ['description','description/index'], name: 'description' + 'Index', moduleId: PLATFORM.moduleName('app-items/description/index'), nav: false, title: 'Description'},
      {route: 'description/create', name: 'description' + 'Create', moduleId: PLATFORM.moduleName('app-items/description/create'), nav: false, title: 'Description Create'},
      {route: 'description/edit/:id', name: 'description' + 'Edit', moduleId: PLATFORM.moduleName('app-items/description/edit'), nav: false, title: 'Description Edit'},
      {route: 'description/delete/:id', name: 'description' + 'Delete', moduleId: PLATFORM.moduleName('app-items/description/delete'), nav: false, title: 'Description Delete'},
      {route: 'description/details/:id', name: 'description' + 'Details', moduleId: PLATFORM.moduleName('app-items/description/details'), nav: false, title: 'Description Details'},

      {route: ['dosage','dosage/index'], name: 'dosage' + 'Index', moduleId: PLATFORM.moduleName('app-items/dosage/index'), nav: false, title: 'Dosage'},
      {route: 'dosage/create', name: 'dosage' + 'Create', moduleId: PLATFORM.moduleName('app-items/dosage/create'), nav: false, title: 'Dosage Create'},
      {route: 'dosage/edit/:id', name: 'dosage' + 'Edit', moduleId: PLATFORM.moduleName('app-items/dosage/edit'), nav: false, title: 'Dosage Edit'},
      {route: 'dosage/delete/:id', name: 'dosage' + 'Delete', moduleId: PLATFORM.moduleName('app-items/dosage/delete'), nav: false, title: 'Dosage Delete'},
      {route: 'dosage/details/:id', name: 'dosage' + 'Details', moduleId: PLATFORM.moduleName('app-items/dosage/details'), nav: false, title: 'Dosage Details'},
      
      {route: ['product','product/index'], name: 'product' + 'Index', moduleId: PLATFORM.moduleName('app-items/product/index'), nav: true, title: 'Product'},
      {route: 'product/create', name: 'product' + 'Create', moduleId: PLATFORM.moduleName('app-items/product/create'), nav: false, title: 'Product Create'},
      {route: 'product/edit/:id', name: 'product' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product/edit'), nav: false, title: 'Product Edit'},
      {route: 'product/delete/:id', name: 'product' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product/delete'), nav: false, title: 'Product Delete'},
      {route: 'product/details/:id', name: 'product' + 'Details', moduleId: PLATFORM.moduleName('app-items/product/details'), nav: false, title: 'Product Details'},
      
      {route: ['product-classification','product-classification/index'], name: 'product-classification' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-classification/index'), nav: false, title: 'Product-classification'},
      {route: 'product-classification/create', name: 'product-classification' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-classification/create'), nav: false, title: 'Product-classification Create'},
      {route: 'product-classification/edit/:id', name: 'product-classification' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-classification/edit'), nav: false, title: 'Product-classification Edit'},
      {route: 'product-classification/delete/:id', name: 'product-classification' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-classification/delete'), nav: false, title: 'Product-classification Delete'},
      {route: 'product-classification/details/:id', name: 'product-classification' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-classification/details'), nav: false, title: 'Product-classification Details'},

      {route: ['product-company','product-company/index'], name: 'product-company' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-company/index'), nav: false, title: 'Product-company'},
      {route: 'product-company/create', name: 'product-company' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-company/create'), nav: false, title: 'Product-company Create'},
      {route: 'product-company/edit/:id', name: 'product-company' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-company/edit'), nav: false, title: 'Product-company Edit'},
      {route: 'product-company/delete/:id', name: 'product-company' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-company/delete'), nav: false, title: 'Product-company Delete'},
      {route: 'product-company/details/:id', name: 'product-company' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-company/details'), nav: false, title: 'Product-company Details'},
      
      {route: ['product-description','product-description/index'], name: 'product-description' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-description/index'), nav: false, title: 'Product-description'},
      {route: 'product-description/create', name: 'product-description' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-description/create'), nav: false, title: 'Product-description Create'},
      {route: 'product-description/edit/:id', name: 'product-description' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-description/edit'), nav: false, title: 'Product-description Edit'},
      {route: 'product-description/delete/:id', name: 'product-description' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-description/delete'), nav: false, title: 'Product-description Delete'},
      {route: 'product-description/details/:id', name: 'product-description' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-description/details'), nav: false, title: 'Product-description Details'},

      {route: ['product-dosage','product-dosage/index'], name: 'product-dosage' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-dosage/index'), nav: false, title: 'Product-dosage'},
      {route: 'product-dosage/create', name: 'product-dosage' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-dosage/create'), nav: false, title: 'Product-dosage Create'},
      {route: 'product-dosage/edit/:id', name: 'product-dosage' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-dosage/edit'), nav: false, title: 'Product-dosage Edit'},
      {route: 'product-dosage/delete/:id', name: 'product-dosage' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-dosage/delete'), nav: false, title: 'Product-dosage Delete'},
      {route: 'product-dosage/details/:id', name: 'product-dosage' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-dosage/details'), nav: false, title: 'Product-dosage Details'},

      {route: ['product-name','product-name/index'], name: 'product-name' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-name/index'), nav: false, title: 'Product-name'},
      {route: 'product-name/create', name: 'product-name' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-name/create'), nav: false, title: 'Product-name Create'},
      {route: 'product-name/edit/:id', name: 'product-name' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-name/edit'), nav: false, title: 'Product-name Edit'},
      {route: 'product-name/delete/:id', name: 'product-name' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-name/delete'), nav: false, title: 'Product-name Delete'},
      {route: 'product-name/details/:id', name: 'product-name' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-name/details'), nav: false, title: 'Product-name Details'},

      {route: ['route-of-administration','route-of-administration/index'], name: 'route-of-administration' + 'Index', moduleId: PLATFORM.moduleName('app-items/route-of-administration/index'), nav: false, title: 'Route-of-administration'},
      {route: 'route-of-administration/create', name: 'route-of-administration' + 'Create', moduleId: PLATFORM.moduleName('app-items/route-of-administration/create'), nav: false, title: 'Route-of-administration Create'},
      {route: 'route-of-administration/edit/:id', name: 'route-of-administration' + 'Edit', moduleId: PLATFORM.moduleName('app-items/route-of-administration/edit'), nav: false, title: 'Route-of-administration Edit'},
      {route: 'route-of-administration/delete/:id', name: 'route-of-administration' + 'Delete', moduleId: PLATFORM.moduleName('app-items/route-of-administration/delete'), nav: false, title: 'Route-of-administration Delete'},
      {route: 'route-of-administration/details/:id', name: 'route-of-administration' + 'Details', moduleId: PLATFORM.moduleName('app-items/route-of-administration/details'), nav: false, title: 'Route-of-administration Details'},
      */
    ]);
  }
  
} 
