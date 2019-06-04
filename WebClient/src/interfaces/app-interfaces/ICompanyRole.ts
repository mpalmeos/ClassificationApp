import {IBaseEntity} from "../IBaseEntity";

export interface ICompanyRole extends IBaseEntity{
  companyName: string,
  companyAddress: string,
  roleValue: string
}
