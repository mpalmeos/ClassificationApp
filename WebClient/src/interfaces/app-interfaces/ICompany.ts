import {IBaseEntity} from "../IBaseEntity";

export interface ICompany extends IBaseEntity{
  companyName: string;
  companyAddress: string;
}
