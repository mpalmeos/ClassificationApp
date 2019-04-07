import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICompany} from "../../interfaces/app-interfaces/ICompany";

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

