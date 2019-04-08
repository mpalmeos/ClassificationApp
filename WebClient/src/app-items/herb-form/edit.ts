import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHerbForm} from "../../interfaces/app-interfaces/IHerbForm";
import {HerbFormService} from "../../services/app-services/herb-form-service";

export var log = LogManager.getLogger('HerbForm.Edit');

@autoinject
export class Edit {

  private herbForm : IHerbForm | null = null;

  constructor(
    private router: Router,
    private herbFormService: HerbFormService
  ) {
    log.debug('constructor');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('herbForm', this.herbForm);
    this.herbFormService.put(this.herbForm!).then(
      response => {
        if (response.status == 204){
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
    log.debug('activate', params);

    this.herbFormService.fetch(params.id).then(
      herbForm => {
        log.debug('herbForm', herbForm);
        this.herbForm = herbForm;
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
