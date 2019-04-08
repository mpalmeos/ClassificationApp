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
      {route: ['company','company/index'], name: 'company' + 'Index', moduleId: PLATFORM.moduleName('app-items/company/index'), nav: false, title: 'Company'},
      {route: 'company/create', name: 'company' + 'Create', moduleId: PLATFORM.moduleName('app-items/company/create'), nav: false, title: 'Company Create'},
      {route: 'company/edit/:id', name: 'company' + 'Edit', moduleId: PLATFORM.moduleName('app-items/company/edit'), nav: false, title: 'Company Edit'},
      {route: 'company/delete/:id', name: 'company' + 'Delete', moduleId: PLATFORM.moduleName('app-items/company/delete'), nav: false, title: 'Company Delete'},
      {route: 'company/details/:id', name: 'company' + 'Details', moduleId: PLATFORM.moduleName('app-items/company/details'), nav: false, title: 'Company Details'},

      {route: ['c-role','c-role/index'], name: 'c-role' + 'Index', moduleId: PLATFORM.moduleName('app-items/c-role/index'), nav: false, title: 'C-role'},
      {route: 'c-role/create', name: 'c-role' + 'Create', moduleId: PLATFORM.moduleName('app-items/c-role/create'), nav: false, title: 'C-role Create'},
      {route: 'c-role/edit/:id', name: 'c-role' + 'Edit', moduleId: PLATFORM.moduleName('app-items/c-role/edit'), nav: false, title: 'C-role Edit'},
      {route: 'c-role/delete/:id', name: 'c-role' + 'Delete', moduleId: PLATFORM.moduleName('app-items/c-role/delete'), nav: false, title: 'C-role Delete'},
      {route: 'c-role/details/:id', name: 'c-role' + 'Details', moduleId: PLATFORM.moduleName('app-items/c-role/details'), nav: false, title: 'C-role Details'},

      {route: ['category','category/index'], name: 'category' + 'Index', moduleId: PLATFORM.moduleName('app-items/category/index'), nav: false, title: 'Category'},
      {route: 'category/create', name: 'category' + 'Create', moduleId: PLATFORM.moduleName('app-items/category/create'), nav: false, title: 'Category Create'},
      {route: 'category/edit/:id', name: 'category' + 'Edit', moduleId: PLATFORM.moduleName('app-items/category/edit'), nav: false, title: 'Category Edit'},
      {route: 'category/delete/:id', name: 'category' + 'Delete', moduleId: PLATFORM.moduleName('app-items/category/delete'), nav: false, title: 'Category Delete'},
      {route: 'category/details/:id', name: 'category' + 'Details', moduleId: PLATFORM.moduleName('app-items/category/details'), nav: false, title: 'Category Details'},

      {route: ['company-role','company-role/index'], name: 'company-role' + 'Index', moduleId: PLATFORM.moduleName('app-items/company-role/index'), nav: false, title: 'Company-role'},
      {route: 'company-role/create', name: 'company-role' + 'Create', moduleId: PLATFORM.moduleName('app-items/company-role/create'), nav: false, title: 'Company-role Create'},
      {route: 'company-role/edit/:id', name: 'company-role' + 'Edit', moduleId: PLATFORM.moduleName('app-items/company-role/edit'), nav: false, title: 'Company-role Edit'},
      {route: 'company-role/delete/:id', name: 'company-role' + 'Delete', moduleId: PLATFORM.moduleName('app-items/company-role/delete'), nav: false, title: 'Company-role Delete'},
      {route: 'company-role/details/:id', name: 'company-role' + 'Details', moduleId: PLATFORM.moduleName('app-items/company-role/details'), nav: false, title: 'Company-role Details'},

      {route: ['composition','composition/index'], name: 'composition' + 'Index', moduleId: PLATFORM.moduleName('app-items/composition/index'), nav: false, title: 'Composition'},
      {route: 'composition/create', name: 'composition' + 'Create', moduleId: PLATFORM.moduleName('app-items/composition/create'), nav: false, title: 'Composition Create'},
      {route: 'composition/edit/:id', name: 'composition' + 'Edit', moduleId: PLATFORM.moduleName('app-items/composition/edit'), nav: false, title: 'Composition Edit'},
      {route: 'composition/delete/:id', name: 'composition' + 'Delete', moduleId: PLATFORM.moduleName('app-items/composition/delete'), nav: false, title: 'Composition Delete'},
      {route: 'composition/details/:id', name: 'composition' + 'Details', moduleId: PLATFORM.moduleName('app-items/composition/details'), nav: false, title: 'Composition Details'},

      {route: ['composition-herb','composition-herb/index'], name: 'composition-herb' + 'Index', moduleId: PLATFORM.moduleName('app-items/composition-herb/index'), nav: false, title: 'Composition-herb'},
      {route: 'composition-herb/create', name: 'composition-herb' + 'Create', moduleId: PLATFORM.moduleName('app-items/composition-herb/create'), nav: false, title: 'Composition-herb Create'},
      {route: 'composition-herb/edit/:id', name: 'composition-herb' + 'Edit', moduleId: PLATFORM.moduleName('app-items/composition-herb/edit'), nav: false, title: 'Composition-herb Edit'},
      {route: 'composition-herb/delete/:id', name: 'composition-herb' + 'Delete', moduleId: PLATFORM.moduleName('app-items/composition-herb/delete'), nav: false, title: 'Composition-herb Delete'},
      {route: 'composition-herb/details/:id', name: 'composition-herb' + 'Details', moduleId: PLATFORM.moduleName('app-items/composition-herb/details'), nav: false, title: 'Composition-herb Details'},

      {route: ['composition-substance','composition-substance/index'], name: 'composition-substance' + 'Index', moduleId: PLATFORM.moduleName('app-items/composition-substance/index'), nav: false, title: 'Composition-substance'},
      {route: 'composition-substance/create', name: 'composition-substance' + 'Create', moduleId: PLATFORM.moduleName('app-items/composition-substance/create'), nav: false, title: 'Composition-substance Create'},
      {route: 'composition-substance/edit/:id', name: 'composition-substance' + 'Edit', moduleId: PLATFORM.moduleName('app-items/composition-substance/edit'), nav: false, title: 'Composition-substance Edit'},
      {route: 'composition-substance/delete/:id', name: 'composition-substance' + 'Delete', moduleId: PLATFORM.moduleName('app-items/composition-substance/delete'), nav: false, title: 'Composition-substance Delete'},
      {route: 'composition-substance/details/:id', name: 'composition-substance' + 'Details', moduleId: PLATFORM.moduleName('app-items/composition-substance/details'), nav: false, title: 'Composition-substance Details'},

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

      {route: ['herb','herb/index'], name: 'herb' + 'Index', moduleId: PLATFORM.moduleName('app-items/herb/index'), nav: false, title: 'Herb'},
      {route: 'herb/create', name: 'herb' + 'Create', moduleId: PLATFORM.moduleName('app-items/herb/create'), nav: false, title: 'Herb Create'},
      {route: 'herb/edit/:id', name: 'herb' + 'Edit', moduleId: PLATFORM.moduleName('app-items/herb/edit'), nav: false, title: 'Herb Edit'},
      {route: 'herb/delete/:id', name: 'herb' + 'Delete', moduleId: PLATFORM.moduleName('app-items/herb/delete'), nav: false, title: 'Herb Delete'},
      {route: 'herb/details/:id', name: 'herb' + 'Details', moduleId: PLATFORM.moduleName('app-items/herb/details'), nav: false, title: 'Herb Details'},

      {route: ['herb-form','herb-form/index'], name: 'herb-form' + 'Index', moduleId: PLATFORM.moduleName('app-items/herb-form/index'), nav: false, title: 'Herb-form'},
      {route: 'herb-form/create', name: 'herb-form' + 'Create', moduleId: PLATFORM.moduleName('app-items/herb-form/create'), nav: false, title: 'Herb-form Create'},
      {route: 'herb-form/edit/:id', name: 'herb-form' + 'Edit', moduleId: PLATFORM.moduleName('app-items/herb-form/edit'), nav: false, title: 'Herb-form Edit'},
      {route: 'herb-form/delete/:id', name: 'herb-form' + 'Delete', moduleId: PLATFORM.moduleName('app-items/herb-form/delete'), nav: false, title: 'Herb-form Delete'},
      {route: 'herb-form/details/:id', name: 'herb-form' + 'Details', moduleId: PLATFORM.moduleName('app-items/herb-form/details'), nav: false, title: 'Herb-form Details'},

      {route: ['herb-medicinal','herb-medicinal/index'], name: 'herb-medicinal' + 'Index', moduleId: PLATFORM.moduleName('app-items/herb-medicinal/index'), nav: false, title: 'Herb-medicinal'},
      {route: 'herb-medicinal/create', name: 'herb-medicinal' + 'Create', moduleId: PLATFORM.moduleName('app-items/herb-medicinal/create'), nav: false, title: 'Herb-medicinal Create'},
      {route: 'herb-medicinal/edit/:id', name: 'herb-medicinal' + 'Edit', moduleId: PLATFORM.moduleName('app-items/herb-medicinal/edit'), nav: false, title: 'Herb-medicinal Edit'},
      {route: 'herb-medicinal/delete/:id', name: 'herb-medicinal' + 'Delete', moduleId: PLATFORM.moduleName('app-items/herb-medicinal/delete'), nav: false, title: 'Herb-medicinal Delete'},
      {route: 'herb-medicinal/details/:id', name: 'herb-medicinal' + 'Details', moduleId: PLATFORM.moduleName('app-items/herb-medicinal/details'), nav: false, title: 'Herb-medicinal Details'},

      {route: ['herb-part','herb-part/index'], name: 'herb-part' + 'Index', moduleId: PLATFORM.moduleName('app-items/herb-part/index'), nav: false, title: 'Herb-part'},
      {route: 'herb-part/create', name: 'herb-part' + 'Create', moduleId: PLATFORM.moduleName('app-items/herb-part/create'), nav: false, title: 'Herb-part Create'},
      {route: 'herb-part/edit/:id', name: 'herb-part' + 'Edit', moduleId: PLATFORM.moduleName('app-items/herb-part/edit'), nav: false, title: 'Herb-part Edit'},
      {route: 'herb-part/delete/:id', name: 'herb-part' + 'Delete', moduleId: PLATFORM.moduleName('app-items/herb-part/delete'), nav: false, title: 'Herb-part Delete'},
      {route: 'herb-part/details/:id', name: 'herb-part' + 'Details', moduleId: PLATFORM.moduleName('app-items/herb-part/details'), nav: false, title: 'Herb-part Details'},

      {route: ['medicinal-dose','medicinal-dose/index'], name: 'medicinal-dose' + 'Index', moduleId: PLATFORM.moduleName('app-items/medicinal-dose/index'), nav: false, title: 'Medicinal-dose'},
      {route: 'medicinal-dose/create', name: 'medicinal-dose' + 'Create', moduleId: PLATFORM.moduleName('app-items/medicinal-dose/create'), nav: false, title: 'Medicinal-dose Create'},
      {route: 'medicinal-dose/edit/:id', name: 'medicinal-dose' + 'Edit', moduleId: PLATFORM.moduleName('app-items/medicinal-dose/edit'), nav: false, title: 'Medicinal-dose Edit'},
      {route: 'medicinal-dose/delete/:id', name: 'medicinal-dose' + 'Delete', moduleId: PLATFORM.moduleName('app-items/medicinal-dose/delete'), nav: false, title: 'Medicinal-dose Delete'},
      {route: 'medicinal-dose/details/:id', name: 'medicinal-dose' + 'Details', moduleId: PLATFORM.moduleName('app-items/medicinal-dose/details'), nav: false, title: 'Medicinal-dose Details'},

      {route: ['plant-form','plant-form/index'], name: 'plant-form' + 'Index', moduleId: PLATFORM.moduleName('app-items/plant-form/index'), nav: false, title: 'Plant-form'},
      {route: 'plant-form/create', name: 'plant-form' + 'Create', moduleId: PLATFORM.moduleName('app-items/plant-form/create'), nav: false, title: 'Plant-form Create'},
      {route: 'plant-form/edit/:id', name: 'plant-form' + 'Edit', moduleId: PLATFORM.moduleName('app-items/plant-form/edit'), nav: false, title: 'Plant-form Edit'},
      {route: 'plant-form/delete/:id', name: 'plant-form' + 'Delete', moduleId: PLATFORM.moduleName('app-items/plant-form/delete'), nav: false, title: 'Plant-form Delete'},
      {route: 'plant-form/details/:id', name: 'plant-form' + 'Details', moduleId: PLATFORM.moduleName('app-items/plant-form/details'), nav: false, title: 'Plant-form Details'},

      {route: ['plant-part','plant-part/index'], name: 'plant-part' + 'Index', moduleId: PLATFORM.moduleName('app-items/plant-part/index'), nav: false, title: 'Plant-part'},
      {route: 'plant-part/create', name: 'plant-part' + 'Create', moduleId: PLATFORM.moduleName('app-items/plant-part/create'), nav: false, title: 'Plant-part Create'},
      {route: 'plant-part/edit/:id', name: 'plant-part' + 'Edit', moduleId: PLATFORM.moduleName('app-items/plant-part/edit'), nav: false, title: 'Plant-part Edit'},
      {route: 'plant-part/delete/:id', name: 'plant-part' + 'Delete', moduleId: PLATFORM.moduleName('app-items/plant-part/delete'), nav: false, title: 'Plant-part Delete'},
      {route: 'plant-part/details/:id', name: 'plant-part' + 'Details', moduleId: PLATFORM.moduleName('app-items/plant-part/details'), nav: false, title: 'Plant-part Details'},

      {route: ['product','product/index'], name: 'product' + 'Index', moduleId: PLATFORM.moduleName('app-items/product/index'), nav: false, title: 'Product'},
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

      {route: ['product-composition','product-composition/index'], name: 'product-composition' + 'Index', moduleId: PLATFORM.moduleName('app-items/product-composition/index'), nav: false, title: 'Product-composition'},
      {route: 'product-composition/create', name: 'product-composition' + 'Create', moduleId: PLATFORM.moduleName('app-items/product-composition/create'), nav: false, title: 'Product-composition Create'},
      {route: 'product-composition/edit/:id', name: 'product-composition' + 'Edit', moduleId: PLATFORM.moduleName('app-items/product-composition/edit'), nav: false, title: 'Product-composition Edit'},
      {route: 'product-composition/delete/:id', name: 'product-composition' + 'Delete', moduleId: PLATFORM.moduleName('app-items/product-composition/delete'), nav: false, title: 'Product-composition Delete'},
      {route: 'product-composition/details/:id', name: 'product-composition' + 'Details', moduleId: PLATFORM.moduleName('app-items/product-composition/details'), nav: false, title: 'Product-composition Details'},

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

      {route: ['substance','substance/index'], name: 'substance' + 'Index', moduleId: PLATFORM.moduleName('app-items/substance/index'), nav: false, title: 'Substance'},
      {route: 'substance/create', name: 'substance' + 'Create', moduleId: PLATFORM.moduleName('app-items/substance/create'), nav: false, title: 'Substance Create'},
      {route: 'substance/edit/:id', name: 'substance' + 'Edit', moduleId: PLATFORM.moduleName('app-items/substance/edit'), nav: false, title: 'Substance Edit'},
      {route: 'substance/delete/:id', name: 'substance' + 'Delete', moduleId: PLATFORM.moduleName('app-items/substance/delete'), nav: false, title: 'Substance Delete'},
      {route: 'substance/details/:id', name: 'substance' + 'Details', moduleId: PLATFORM.moduleName('app-items/substance/details'), nav: false, title: 'Substance Details'},

      {route: ['substance-category','substance-category/index'], name: 'substance-category' + 'Index', moduleId: PLATFORM.moduleName('app-items/substance-category/index'), nav: false, title: 'Substance-category'},
      {route: 'substance-category/create', name: 'substance-category' + 'Create', moduleId: PLATFORM.moduleName('app-items/substance-category/create'), nav: false, title: 'Substance-category Create'},
      {route: 'substance-category/edit/:id', name: 'substance-category' + 'Edit', moduleId: PLATFORM.moduleName('app-items/substance-category/edit'), nav: false, title: 'Substance-category Edit'},
      {route: 'substance-category/delete/:id', name: 'substance-category' + 'Delete', moduleId: PLATFORM.moduleName('app-items/substance-category/delete'), nav: false, title: 'Substance-category Delete'},
      {route: 'substance-category/details/:id', name: 'substance-category' + 'Details', moduleId: PLATFORM.moduleName('app-items/substance-category/details'), nav: false, title: 'Substance-category Details'},

      {route: ['substance-medicinal','substance-medicinal/index'], name: 'substance-medicinal' + 'Index', moduleId: PLATFORM.moduleName('app-items/substance-medicinal/index'), nav: false, title: 'Substance-medicinal'},
      {route: 'substance-medicinal/create', name: 'substance-medicinal' + 'Create', moduleId: PLATFORM.moduleName('app-items/substance-medicinal/create'), nav: false, title: 'Substance-medicinal Create'},
      {route: 'substance-medicinal/edit/:id', name: 'substance-medicinal' + 'Edit', moduleId: PLATFORM.moduleName('app-items/substance-medicinal/edit'), nav: false, title: 'Substance-medicinal Edit'},
      {route: 'substance-medicinal/delete/:id', name: 'substance-medicinal' + 'Delete', moduleId: PLATFORM.moduleName('app-items/substance-medicinal/delete'), nav: false, title: 'Substance-medicinal Delete'},
      {route: 'substance-medicinal/details/:id', name: 'substance-medicinal' + 'Details', moduleId: PLATFORM.moduleName('app-items/substance-medicinal/details'), nav: false, title: 'Substance-medicinal Details'},

      {route: ['unit-of-measure','unit-of-measure/index'], name: 'unit-of-measure' + 'Index', moduleId: PLATFORM.moduleName('app-items/unit-of-measure/index'), nav: false, title: 'Unit-of-measure'},
      {route: 'unit-of-measure/create', name: 'unit-of-measure' + 'Create', moduleId: PLATFORM.moduleName('app-items/unit-of-measure/create'), nav: false, title: 'Unit-of-measure Create'},
      {route: 'unit-of-measure/edit/:id', name: 'unit-of-measure' + 'Edit', moduleId: PLATFORM.moduleName('app-items/unit-of-measure/edit'), nav: false, title: 'Unit-of-measure Edit'},
      {route: 'unit-of-measure/delete/:id', name: 'unit-of-measure' + 'Delete', moduleId: PLATFORM.moduleName('app-items/unit-of-measure/delete'), nav: false, title: 'Unit-of-measure Delete'},
      {route: 'unit-of-measure/details/:id', name: 'unit-of-measure' + 'Details', moduleId: PLATFORM.moduleName('app-items/unit-of-measure/details'), nav: false, title: 'Unit-of-measure Details'},

    ]);
  }
  
} 
