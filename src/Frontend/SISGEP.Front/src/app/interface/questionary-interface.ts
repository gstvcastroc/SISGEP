import { Guid } from "guid-typescript";

export interface Survey {
  surveyId : Guid;
  name : string;
  date : Date;
  structure : string;
  projectId : Guid;
}

export interface FilledSurvey {
  filledSurveyId : Guid;
  structure : string;
  date : Date;
  surveyId : Guid;
  personId : Guid;
}
