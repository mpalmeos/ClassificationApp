import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {ISubstanceCategory} from "../../interfaces/app-interfaces/ISubstanceCategory";
import {SubstanceCategoryService} from "../../services/app-services/substance-category-service";

export var log = LogManager.getLogger("SubstanceCategory.Create");

@autoinject
export class Create {

  private substanceCategory: ISubstanceCategory;
  
  constructor(
    private router: Router,
    private substanceCategoryService: SubstanceCategoryService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('substanceCategory', this.substanceCategory);
    this.substanceCategoryService.post(this.substanceCategory).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("substanceCategoryIndex");
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
    log.debug('activate');
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }

}
