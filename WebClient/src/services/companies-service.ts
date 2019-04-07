import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {ICompany} from "../interfaces/ICompany";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('CompanyService');

@autoinject
export class CompanyService extends BaseService<ICompany> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Company');
  }

}

