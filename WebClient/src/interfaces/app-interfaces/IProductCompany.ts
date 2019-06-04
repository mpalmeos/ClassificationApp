import {IBaseEntity} from "../IBaseEntity";
import {IProduct} from "./IProduct";
import {ICompany} from "./ICompany";

export interface IProductCompany extends IBaseEntity{
  product: IProduct,
  company: ICompany
}
