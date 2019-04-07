import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IHerbForm} from "../../interfaces/app-interfaces/IHerbForm";

export var log = LogManager.getLogger('HerbFormService');

@autoinject
export class HerbFormService extends BaseService<IHerbForm> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'HerbForm');
  }
}
