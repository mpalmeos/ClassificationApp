import {IBaseEntity} from "../IBaseEntity";
import {IProduct} from "./IProduct";
import {IDescription} from "./IDescription";

export interface IProductDescription extends IBaseEntity{
  product: IProduct,
  description: IDescription
}
