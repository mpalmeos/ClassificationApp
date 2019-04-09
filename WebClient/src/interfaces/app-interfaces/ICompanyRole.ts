import {IBaseEntity} from "../IBaseEntity";

export interface ICompanyRole extends IBaseEntity{
  "CompanyName": string,
  "CompanyAddress": string,
  "RoleValue": string
}
