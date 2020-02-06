import React, {FC, useEffect} from 'react';
import { Layout, StudentList } from 'components';
import { compose } from 'recompose';
import { connect } from 'react-redux';
import { IDispatchable } from 'models';
import { fetchStudents } from 'redux-store/student/actions';
import './styles.scss';



export const Student: FC<IDispatchable> = ({ dispatch }) => {
  // Similar to componentDidMount and componentDidUpdate:
  useEffect(() => {
    dispatch(fetchStudents());
  });

  return (
    <Layout title="List of Students" description="This is the List of Students Page">
      <StudentList students={[]} />
    </Layout>
  );
};

export default compose<IDispatchable, IDispatchable>(connect())(Student);
