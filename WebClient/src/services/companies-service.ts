import {LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import {HttpClient} from "aurelia-fetch-client";
import {ICompany} from "../interfaces/ICompany";

export var log = LogManager.getLogger("app.CompaniesService");

@autoinject
export class CompaniesService {

  constructor(private httpClient: HttpClient){
    log.debug('constructor running');
  }
  
  fetchAll(): Promise<ICompany[]> {
    let url = "https://localhost:5001/api/Company";
    
    return this.httpClient.get(url, {cache: 'no-store'}).then(
      response => {
        log.debug('response', response);
        return response.json();
      }
    ).then(jsonData => {
      log.debug('jsonData', jsonData);
      return jsonData;
    }).catch(
      reason => {
        log.debug('catch reason', reason);
      }
    );
  }
}
