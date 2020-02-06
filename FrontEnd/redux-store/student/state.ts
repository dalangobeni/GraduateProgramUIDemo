import { IStudent } from "models";

export type StudentErrable =
'fetchStudentsErrorMsg';
  /* new-errable-goes-here */;

export type StudentBooleanable =
'isFetchingStudents';
  /* new-booleanable-goes-here */;

export type StudentSuccessible =
'fetchStudentsSuccessMsg';
  /* new-successible-goes-here */;

export interface IStudentState{
  readonly students?: IStudent[];
  //#region Doables
  readonly errable?: { [key in StudentErrable]?: string };
  readonly booleanable?: { [key in StudentBooleanable]?: boolean };
  readonly successible?: { [key in StudentSuccessible]?: string };
  //#endregion
}
