import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICategory} from "../../interfaces/app-interfaces/ICategory";
import {CategoryService} from "../../services/app-services/category-service";

export var log = LogManager.getLogger('Category.Delete');

@autoinject
export class Delete {

  private category: ICategory;

  constructor(
    private router: Router,
    private categoryService: CategoryService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.categoryService.delete(this.category.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("categoryIndex");
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
    this.categoryService.fetch(params.id).then(
      category => {
        log.debug('category', category);
        this.category = category;
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
