import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IDosage} from "../../interfaces/app-interfaces/IDosage";

export var log = LogManager.getLogger('DosageService');

@autoinject
export class DosageService extends BaseService<IDosage> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Dosage');
  }
}
