import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {ICompanyRole} from "../../interfaces/app-interfaces/ICompanyRole";

export var log = LogManager.getLogger('CompanyRoleService');

@autoinject
export class CompanyRoleService extends BaseService<ICompanyRole> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'CompanyRole');
  }
}
