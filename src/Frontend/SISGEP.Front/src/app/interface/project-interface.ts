import { Guid } from "guid-typescript";
import { Person } from "./person-interface";
import { Survey } from "./questionary-interface";

export interface Project {
  projectId: Guid;
  name: string;
  description: string;
  isActive: boolean;
  startDate: Date;
  endDate: Date;
  survey: Survey[];
  persons: Person[];
}
