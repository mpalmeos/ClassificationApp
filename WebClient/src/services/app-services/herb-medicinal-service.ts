import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IHerbMedicinal} from "../../interfaces/app-interfaces/IHerbMedicinal";

export var log = LogManager.getLogger('HerbMedicinalService');

@autoinject
export class HerbMedicinalService extends BaseService<IHerbMedicinal> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'HerbMedicinal');
  }
}
