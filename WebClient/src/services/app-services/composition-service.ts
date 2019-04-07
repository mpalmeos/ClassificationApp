import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IComposition} from "../../interfaces/app-interfaces/IComposition";

export var log = LogManager.getLogger('CompositionService');

@autoinject
export class CompositionService extends BaseService<IComposition> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Composition');
  }
}
