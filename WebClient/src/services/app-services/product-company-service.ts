import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductCompany} from "../../interfaces/app-interfaces/IProductCompany";

export var log = LogManager.getLogger('ProductCompanyService');

@autoinject
export class ProductCompanyService extends BaseService<IProductCompany> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductCompany');
  }
}
