import { all, call, takeLatest, put } from 'redux-saga/effects';
import { fetchAllStudentsApi } from 'api/studentsApi';
import {
 FETCH_STUDENTS,
/* new-constant-import-goes-here */
} from './constants';
import {
   fetchStudentsSuccess, fetchStudentsError
  /* new-action-import-goes-here */
} from './actions';

function* fetchStudentsSaga() {
  const response = yield call(fetchAllStudentsApi);

  try {
    const { status, data } = response;

    if (status === 200) {
      yield put(fetchStudentsSuccess(data));
    } else {
      yield put(fetchStudentsError('Sorry! An error occured!'));
    }
  } catch (error) {
    yield put(fetchStudentsError('Sorry! An error occured!'));
  }
}

/* new-saga-goes-here */
export default function* rootSaga() {
  yield all([takeLatest(FETCH_STUDENTS, fetchStudentsSaga)]);
}

