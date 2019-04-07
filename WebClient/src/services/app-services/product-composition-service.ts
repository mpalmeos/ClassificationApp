import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductComposition} from "../../interfaces/app-interfaces/IProductComposition";

export var log = LogManager.getLogger('ProductCompositionService');

@autoinject
export class ProductCompositionService extends BaseService<IProductComposition> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductComposition');
  }
}
