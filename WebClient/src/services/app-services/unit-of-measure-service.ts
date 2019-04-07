import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IUnitOfMeasure} from "../../interfaces/app-interfaces/IUnitOfMeasure";

export var log = LogManager.getLogger('UnitOfMeasureService');

@autoinject
export class UnitOfMeasureService extends BaseService<IUnitOfMeasure> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'UnitOfMeasure');
  }
}
