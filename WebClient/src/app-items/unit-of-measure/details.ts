import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IUnitOfMeasure} from "../../interfaces/app-interfaces/IUnitOfMeasure";
import {UnitOfMeasureService} from "../../services/app-services/unit-of-measure-service";

export var log = LogManager.getLogger('UnitOfMeasure.Details');

@autoinject
export class Details {

  private unitOfMeasure: IUnitOfMeasure | null = null;

  constructor(
    private router: Router,
    private unitOfMeasureService: UnitOfMeasureService
  ) {
    log.debug('constructor');
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
    this.unitOfMeasureService.fetch(params.id).then(
      unitOfMeasure => {
        log.debug('unitOfMeasure', unitOfMeasure);
        this.unitOfMeasure = unitOfMeasure;
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
