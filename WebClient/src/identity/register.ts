import {LogManager, autoinject, View} from "aurelia-framework";
import {ICompany} from "../interfaces/ICompany";
import {IdentityService} from "../services/identity-service";

export var log = LogManager.getLogger("app.Register.Index");

@autoinject
export class Register {

  private companies : ICompany[];

  constructor(private identityService: IdentityService){
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
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
    log.debug('unbind');
  }

}
