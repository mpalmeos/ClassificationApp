import {IBaseEntity} from "../IBaseEntity";

export interface ICompanyRole extends IBaseEntity{
  "id": number,
  "CompanyName": string,
  "CompanyAddress": string,
  "RoleValue": string
}
