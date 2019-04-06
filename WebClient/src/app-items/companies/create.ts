import {LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";

export var log = LogManager.getLogger("app.Companies.Create");

@autoinject
export class Home {

  constructor(){
    log.debug('constructor running');
  }
}
