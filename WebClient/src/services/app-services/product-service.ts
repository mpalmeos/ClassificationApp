import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProduct} from "../../interfaces/app-interfaces/IProduct";

export var log = LogManager.getLogger('ProductService');

@autoinject
export class ProductService extends BaseService<IProduct> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Product');
    
  }
}
