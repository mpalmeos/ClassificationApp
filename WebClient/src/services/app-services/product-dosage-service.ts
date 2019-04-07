import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductDosage} from "../../interfaces/app-interfaces/IProductDosage";

export var log = LogManager.getLogger('ProductDosageService');

@autoinject
export class ProductDosageService extends BaseService<IProductDosage> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductDosage');
  }
}
