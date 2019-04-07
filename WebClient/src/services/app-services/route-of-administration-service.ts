import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IRouteOfAdministration} from "../../interfaces/app-interfaces/IRouteOfAdministration";

export var log = LogManager.getLogger('RouteOfAdministrationService');

@autoinject
export class RouteOfAdministrationService extends BaseService<IRouteOfAdministration> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'RouteOfAdministration');
  }
}
