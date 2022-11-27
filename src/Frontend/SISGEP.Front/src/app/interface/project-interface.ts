import { Guid } from "guid-typescript";
import { Person } from "./person-interface";
import { Survey } from "./questionary-interface";

export interface Project {
  ProjectId: Guid;
  Name: string;
  Description: string;
  IsActive: boolean;
  StartDate: Date;
  EndDate: Date;
  Survey: Survey[];
  Persons: Person[];
}
