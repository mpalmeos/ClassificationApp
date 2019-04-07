import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductName} from "../../interfaces/app-interfaces/IProductName";

export var log = LogManager.getLogger('ProductNameService');

@autoinject
export class ProductNameService extends BaseService<IProductName> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductName');
  }
}
