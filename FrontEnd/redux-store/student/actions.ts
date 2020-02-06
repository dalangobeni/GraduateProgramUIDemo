import { createAction } from 'redux-actions';
import {
  RESET_STUDENT_DOABLES,
  TOGGLE_STUDENT_BOOLEANABLE_STATE,
  TOGGLE_STUDENT_ERRABLE_STATE,
  TOGGLE_STUDENT_SUCCESSIBLE_STATE,
  /* new-constant-import-goes-here */
  FETCH_STUDENTS,
  FETCH_STUDENTS_SUCCESS,
  FETCH_STUDENTS_ERROR,
} from './constants';
import { IStudent } from 'models';

import {
  IStudentState,
  StudentErrable,
  StudentBooleanable,
  StudentSuccessible,
} from './state';

export const fetchStudents = createAction<IStudentState>(FETCH_STUDENTS, () => ({
  booleanable: { isFetchingStudents: true },
  errable: { fetchStudentsErrorMsg: null },
  successible: { fetchStudentsSuccessMsg: null }, // Not always necessary. Just for demonstration on how to use it
}));

export const fetchStudentsSuccess = createAction<IStudentState, IStudent[]>(FETCH_STUDENTS_SUCCESS, students => ({
  students,
  successible: { fetchStudentsSuccessMsg: 'Yay, We got the Students back!' },
  booleanable: { isFetchingStudents: false },
}));

export const fetchStudentsError = createAction<IStudentState, string>(FETCH_STUDENTS_ERROR, fetchStudentsErrorMsg => ({
  errable: { fetchStudentsErrorMsg },
  booleanable: { isFetchingStudents: false },
}));

//#region Doables
export const resetStudentDoables = createAction<IStudentState>(RESET_STUDENT_DOABLES, () => ({
  errable: {},
  booleanable: {},
  successible: {},
}));

export const toggleStudentBooleanableState = createAction<
  IStudentState,
  { [key in StudentBooleanable]?: boolean }
>(TOGGLE_STUDENT_BOOLEANABLE_STATE, key => ({
  booleanable: key,
}));

export const toggleStudentErrableState = createAction<IStudentState, { [key in StudentErrable]?: string }>(
  TOGGLE_STUDENT_ERRABLE_STATE,
  key => ({
    errable: key,
  })
);

export const toggleStudentSuccessibleState = createAction<
  IStudentState,
  { [key in StudentSuccessible]?: string }
>(TOGGLE_STUDENT_SUCCESSIBLE_STATE, key => ({
  successible: key,
}));
//#endregion

/* new-actions-go-here */