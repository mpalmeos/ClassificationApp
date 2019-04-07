import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IPlantForm} from "../../interfaces/app-interfaces/IPlantForm";

export var log = LogManager.getLogger('PlantFormService');

@autoinject
export class PlantFormService extends BaseService<IPlantForm> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'PlantForm');
  }
}
