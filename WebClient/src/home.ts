import {LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";

export var log = LogManager.getLogger("app.Home");

@autoinject
export class Home {
  
  constructor(){
    log.debug('constructor running');
  }
}
