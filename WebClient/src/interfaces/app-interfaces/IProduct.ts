import {IBaseEntity} from "../IBaseEntity";

export interface IProduct extends IBaseEntity{
  "productName": string,
  "productClassification": string,
  "routeOfAdministration": string
}
