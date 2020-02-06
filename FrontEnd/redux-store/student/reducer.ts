import { 
  DEFAULT_ACTION,
  RESET_STUDENT_DOABLES,
  TOGGLE_STUDENT_BOOLEANABLE_STATE,
  TOGGLE_STUDENT_ERRABLE_STATE,
  TOGGLE_STUDENT_SUCCESSIBLE_STATE,
  /* new-constant-import-goes-here */
  FETCH_STUDENTS,
  FETCH_STUDENTS_SUCCESS,
  FETCH_STUDENTS_ERROR,
} from './constants';

import { IStudentState } from './state';
import { reducerPayloadDoableHelper } from 'redux-store/rootReducer';

const initialState: IStudentState = {
  students: [],
  errable: {},
  booleanable: {},
  successible: {},
};

export default (
  state: IStudentState = initialState,
  { type, payload: incomingPayload }: ReduxActions.Action<IStudentState>
) => {
  const payload =
    type === RESET_STUDENT_DOABLES
      ? incomingPayload
      : (reducerPayloadDoableHelper(state, incomingPayload) as IStudentState);

  switch (type) {
    case TOGGLE_STUDENT_BOOLEANABLE_STATE:
    case TOGGLE_STUDENT_ERRABLE_STATE:
    case TOGGLE_STUDENT_SUCCESSIBLE_STATE:
    /* new-constant-cases-go-here */
    case FETCH_STUDENTS:
    case FETCH_STUDENTS_SUCCESS:
    case FETCH_STUDENTS_ERROR:
    case DEFAULT_ACTION:
      return {
        ...state, 
        ...payload,
      }
    default:
      return state;
  }
};

