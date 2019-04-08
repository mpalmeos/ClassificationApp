import {LogManager, autoinject, View} from "aurelia-framework";
import {Router, RouteConfig, NavigationInstruction} from "aurelia-router";
import {IUnitOfMeasure} from "../../interfaces/app-interfaces/IUnitOfMeasure";
import {UnitOfMeasureService} from "../../services/app-services/unit-of-measure-service";

export var log = LogManager.getLogger("UnitOfMeasure.Create");

@autoinject
export class Create {

  private unitOfMeasure: IUnitOfMeasure;
  
  constructor(
    private router: Router,
    private unitOfMeasureService: UnitOfMeasureService
  ){
    log.debug('constructor running');
  }

  // ============ View methods ==============
  submit():void{
    log.debug('unitOfMeasure', this.unitOfMeasure);
    this.unitOfMeasureService.post(this.unitOfMeasure).then(
      response => {
        if (response.status == 201){
          this.router.navigateToRoute("unitOfMeasureIndex");
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
