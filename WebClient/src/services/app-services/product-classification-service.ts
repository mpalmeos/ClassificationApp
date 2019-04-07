import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductClassification} from "../../interfaces/app-interfaces/IProductClassification";

export var log = LogManager.getLogger('ProductClassificationService');

@autoinject
export class ProductClassificationService extends BaseService<IProductClassification> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductClassification');
  }
}
