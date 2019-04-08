import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHerbForm} from "../../interfaces/app-interfaces/IHerbForm";
import {HerbFormService} from "../../services/app-services/herb-form-service";

export var log = LogManager.getLogger("HerbForm.Create");

@autoinject
export class Create {

  private herbForm: IHerbForm;
  
  constructor(
    private router: Router,
    private herbFormService: HerbFormService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbForm', this.herbForm);
    this.herbFormService.post(this.herbForm).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("herbFormIndex");
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
