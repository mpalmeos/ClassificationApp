import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ISubstance} from "../../interfaces/app-interfaces/ISubstance";

export var log = LogManager.getLogger('SubstanceService');

@autoinject
export class SubstanceService extends BaseService<ISubstance> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Substance');
  }
}
