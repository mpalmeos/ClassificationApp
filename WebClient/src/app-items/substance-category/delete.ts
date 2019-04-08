import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ISubstanceCategory} from "../../interfaces/app-interfaces/ISubstanceCategory";
import {SubstanceCategoryService} from "../../services/app-services/substance-category-service";

export var log = LogManager.getLogger('SubstanceCategory.Delete');

@autoinject
export class Delete {

  private substanceCategory: ISubstanceCategory;

  constructor(
    private router: Router,
    private substanceCategoryService: SubstanceCategoryService
  ) {
    log.debug('constructor');
  }

  // ============ View Methods ==============

  submit():void{
    this.substanceCategoryService.delete(this.substanceCategory.id).then(response => {
      if (response.status == 200){
        this.router.navigateToRoute("substanceCategoryIndex");
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
    this.substanceCategoryService.fetch(params.id).then(
      substanceCategory => {
        log.debug('substanceCategory', substanceCategory);
        this.substanceCategory = substanceCategory;
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
