import { createSelector } from 'reselect';
import { IStoreState } from '../storeState';
import {
  StudentErrable,
  StudentBooleanable,
  StudentSuccessible,
} from './state';

export const studentState = () => (state: IStoreState) => state.student;

export const selectAllStudents = () =>
  createSelector(
    studentState(),
    state => state.students
  );
//#region Doables
/**
 * Returns true if the evaluation of a booleanable state of a given key(s) is true
 * @param key the key to compare to
 */
export const selectStudentBooleanableState = (key: StudentBooleanable | StudentBooleanable[]) =>
createSelector(
  studentState(),
  ({ booleanable }) => (Array.isArray(key) ? !!key.filter(k => booleanable[k]).length : booleanable[key])
);

/**
 * Returns the errable state of a given key(s) is true
 * @param key the key to compare to
 */
export const selectStudentErrableState = (key: StudentErrable | StudentErrable[]) =>
createSelector(
  studentState(),
  ({ errable }) => (Array.isArray(key) ? !!key.filter(k => errable[k]).length : errable[key])
);

/**
 * Returns the successible state of a given key(s) is true
 * @param key the key to compare to
 */
export const selectStudentSuccessibleState = (key: StudentSuccessible | StudentSuccessible[]) =>
createSelector(
  studentState(),
  ({ successible }) => (Array.isArray(key) ? !!key.filter(k => successible[k]).length : successible[key])
);
//#endregion