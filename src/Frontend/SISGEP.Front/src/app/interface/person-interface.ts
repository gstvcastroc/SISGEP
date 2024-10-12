import { Guid } from "guid-typescript";
import { Project } from "./project-interface";
import { FilledSurvey } from "./questionary-interface";

export interface Person {
  personId: Guid;
  name: string;
  email: string;
  password: string;
  isActive: boolean;
  cpf: string;
  personType: PersonType;

  address: {
    addressId: Guid;
    postalCode: string;
    thoroughfare: string;
    number: number;
    neighborhood: string;
    complement: string;
    city: string;
    state: string;
    personId: Guid;
  };

  projects : Project[];
  filledSurvey : FilledSurvey[];
}

export enum PersonType
{
    Manager,
    Voluntary,
    Benefited
}
