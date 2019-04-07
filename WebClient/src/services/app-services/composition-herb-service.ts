import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICompositionHerb} from "../../interfaces/app-interfaces/ICompositionHerb";

export var log = LogManager.getLogger('CompositionHerbService');

@autoinject
export class CompositionHerbService extends BaseService<ICompositionHerb> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'CompositionHerb');
  }
}
