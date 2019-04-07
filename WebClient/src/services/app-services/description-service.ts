import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IDescription} from "../../interfaces/app-interfaces/IDescription";

export var log = LogManager.getLogger('DescriptionService');

@autoinject
export class DescriptionService extends BaseService<IDescription> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Description');
  }
}
