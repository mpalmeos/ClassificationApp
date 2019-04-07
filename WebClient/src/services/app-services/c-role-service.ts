import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICRole} from "../../interfaces/app-interfaces/ICRole";

export var log = LogManager.getLogger('CRoleService');

@autoinject
export class CRoleService extends BaseService<ICRole> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'CRole');
  }
}
