import { IPostsState } from './posts/state';
import { IStudentState } from './student/state';
/* new-imported-state-goes-here */

export interface IStoreState {
  readonly posts: IPostsState;
  readonly student: IStudentState;
	/* new-imported-state-key-goes-here */
}
