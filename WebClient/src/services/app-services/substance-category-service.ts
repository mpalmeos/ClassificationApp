import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ISubstanceCategory} from "../../interfaces/app-interfaces/ISubstanceCategory";

export var log = LogManager.getLogger('SubstanceCategoryService');

@autoinject
export class SubstanceCategoryService extends BaseService<ISubstanceCategory> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'SubstanceCategory');
  }
}
