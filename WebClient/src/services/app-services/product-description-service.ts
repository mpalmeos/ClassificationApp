import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {AppConfig} from "../../app-config";
import {BaseService} from "../base-service";
import {IProductDescription} from "../../interfaces/app-interfaces/IProductDescription";

export var log = LogManager.getLogger('ProductDescriptionService');

@autoinject
export class ProductDescriptionService extends BaseService<IProductDescription> {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'ProductDescription');
  }

  fetchByProduct(productId: number): Promise<IProductDescription> {
    let url = this.appConfig.apiUrl + 'ProductDescription' + '/' + productId;

    return this.httpClient.fetch(url, {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.appConfig.jwt,
      }
    })
      .then(response => {
        log.debug('resonse', response);
        return response.json();
      })
      .then(jsonData => {
        log.debug('jsonData', jsonData);
        return jsonData;
      }).catch(reason => {
        log.debug('catch reason', reason);
      });
  }

}
