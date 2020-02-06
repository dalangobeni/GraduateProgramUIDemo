import React, {FC} from 'react';
import uuid from 'uuid/v4';
import StudentItem from '../studentItem';
import { createSelector } from 'reselect';
import { compose } from 'recompose';
import { connect } from 'react-redux';
import { IStudent } from 'models';
import './styles.scss';
import { selectAllStudents } from 'redux-store/student/selectors';

interface IProps {
  readonly students: IStudent[];
};

export const StudentList: FC<IProps> = ({students}) => (
  <React.Fragment>
  <h1>Students</h1>
  {students.map(student => (
    <StudentItem student={student} key={uuid()} />
  ))}
</React.Fragment>
);

const mapStateToProps = createSelector(
  selectAllStudents(),
  students => ({ students })
);

const withConnect = connect(mapStateToProps);

export default compose<IProps, IProps>(withConnect)(StudentList);
