import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IMedicinalDose} from "../../interfaces/app-interfaces/IMedicinalDose";

export var log = LogManager.getLogger('MedicinalDoseService');

@autoinject
export class MedicinalDoseService extends BaseService<IMedicinalDose> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'MedicinalDose');
  }
}
