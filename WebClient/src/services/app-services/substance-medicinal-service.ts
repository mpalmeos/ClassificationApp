import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ISubstanceMedicinal} from "../../interfaces/app-interfaces/ISubstanceMedicinal";

export var log = LogManager.getLogger('SubstanceMedicinalService');

@autoinject
export class SubstanceMedicinalService extends BaseService<ISubstanceMedicinal> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'SubstanceMedicinal');
  }
}
