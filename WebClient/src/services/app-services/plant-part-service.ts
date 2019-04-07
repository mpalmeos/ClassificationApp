import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IPlantPart} from "../../interfaces/app-interfaces/IPlantPart";

export var log = LogManager.getLogger('PlantPartService');

@autoinject
export class PlantPartService extends BaseService<IPlantPart> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'PlantPart');
  }
}
