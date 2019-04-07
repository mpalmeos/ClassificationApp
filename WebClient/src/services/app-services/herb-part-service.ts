import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IHerbPart} from "../../interfaces/app-interfaces/IHerbPart";

export var log = LogManager.getLogger('HerbPartService');

@autoinject
export class HerbPartService extends BaseService<IHerbPart> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'HerbPart');
  }
}
