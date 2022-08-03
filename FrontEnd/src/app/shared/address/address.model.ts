import { Guid } from "guid-typescript";

export class Address {
    id:Guid;
    personalDataId:Guid;
    addressTypeId:Guid;
    streetAddress:string;
    building:string;
    rtrw:string;
    kelurahan:string;
    kecamatan:string;
    city:string;
    postalCode:string;
}