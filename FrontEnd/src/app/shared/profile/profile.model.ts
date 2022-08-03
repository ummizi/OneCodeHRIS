import { Guid } from "guid-typescript";

export class Profile {
    id:Guid;
    createdBy:string;
    createdDate:Date;
    updatedBy:string;
    updatedDate:Date;
    statusDelete:string;
    description:string;
    maritalStatusId:Guid;
    nik:string;
    firstName:string;
    lastName:string;
    placeOfBirth:string;
    dateOfBirth:string;
    gender:string;
    joinDate:Date;

}
