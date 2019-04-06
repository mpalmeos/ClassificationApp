import {LogManager, autoinject, View} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import {CompaniesService} from "../services/companies-service";
import {ICompany} from "../interfaces/ICompany";

export var log = LogManager.getLogger("app.Comapnies.Index");

@autoinject
export class Companies {

  private companies : ICompany[];
  
  constructor(private companiesService: CompaniesService){
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

    this.companiesService.fetchAll().then(
      jsonData => {
        this.companies = jsonData;
      }
    );
  }

  detached(){
    log.debug('detached');
  }

  unbind(){
    log.debug('unbind');
  }

}
