import React, {FC} from 'react';
import Layout from 'components/global/layout';
import './styles.scss';

interface IProps {};

export const Course: FC<IProps> = () => (
  <Layout title="Course" description="This is the Course Page">
    <div className="course-page">
      <p>
        This is the <strong>Course</strong> page
      </p>
    </div>
  </Layout>
);

export default Course;
