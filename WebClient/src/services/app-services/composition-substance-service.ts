import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICompositionSubstance} from "../../interfaces/app-interfaces/ICompositionSubstance";

export var log = LogManager.getLogger('CompositionSubstance');

@autoinject
export class CompositionSubstanceService extends BaseService<ICompositionSubstance> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'CompositionSubstance');
  }
}
