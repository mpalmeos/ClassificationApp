import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICategory} from "../../interfaces/app-interfaces/ICategory";

export var log = LogManager.getLogger('CategoryService');

@autoinject
export class CategoryService extends BaseService<ICategory> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Category');
  }
}
