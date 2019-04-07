import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IHerb} from "../../interfaces/app-interfaces/IHerb";

export var log = LogManager.getLogger('HerbService');

@autoinject
export class HerbService extends BaseService<IHerb> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Herb');
  }
}
