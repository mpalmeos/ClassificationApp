import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";

export var log = LogManager.getLogger('ProductDescriptionService');

@autoinject
export class ProductDescriptionService extends BaseService<IProductDescription> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductDescription');
  }
}
