import {LogManager, autoinject, View} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IUnitOfMeasure} from "../../interfaces/app-interfaces/IUnitOfMeasure";
import {UnitOfMeasureService} from "../../services/app-services/unit-of-measure-service";

export var log = LogManager.getLogger("UnitOfMeasures.Index");

@autoinject
export class Index {

  private unitOfMeasures : IUnitOfMeasure[] = [];
  
  constructor(private unitOfMeasureService: UnitOfMeasureService){
    log.debug('constructor running');
  }

  created(owningView: View, myView: View){
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object){
    log.debug('bind');
  }

  attached(){
    log.debug('attached');

    this.unitOfMeasureService.fetchAll().then(
      jsonData => {
        this.unitOfMeasures = jsonData;
      }
    );
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
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
