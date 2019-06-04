import {IBaseEntity} from "../IBaseEntity";
import {IRouteOfAdministration} from "./IRouteOfAdministration";
import {IProductClassification} from "./IProductClassification";
import {IProductName} from "./IProductName";

export interface IProduct extends IBaseEntity{
  productName: IProductName,
  productClassification: IProductClassification,
  routeOfAdministration: IRouteOfAdministration
}
