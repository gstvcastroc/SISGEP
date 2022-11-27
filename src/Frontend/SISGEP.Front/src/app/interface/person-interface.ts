import { Guid } from "guid-typescript";
import { Project } from "./project-interface";
import { FilledSurvey } from "./questionary-interface";

export interface Person {
  PersonId: Guid;
  Name: string;
  Password: string;
  IsActive: boolean;
  Cpf: string;
  PersonType: PersonType;

  Address: {
    AddressId: Guid;
    PostalCode: string;
    Thoroughfare: string;
    Number: number;
    Complement: string;
    City: string;
    State: string;
    PersonId: Guid;
  };

  Projects : Project[];
  FilledSurvey : FilledSurvey[];
}

enum PersonType
{
    Manager,
    Voluntary,
    Benefited
}
