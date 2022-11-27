import { Guid } from "guid-typescript";

export interface Survey {
  SurveyId : Guid;
  Name : string;
  Date : Date;
  Structure : string;
  ProjectId : Guid;
}

export interface FilledSurvey {
  FilledSurveyId : Guid;
  Structure : string;
  Date : Date;
  SurveyId : Guid;
  PersonID : Guid;
}
