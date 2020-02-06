import React, {FC} from 'react';
import { IStudent } from 'models';
import { Card } from 'antd';
import './styles.scss';

interface IProps {
  readonly student: IStudent;
};

export const StudentItem: FC<IProps> = ({student}) => {
  return (
    <Card
      hoverable
      title={student.name}>
      <p>{student.address}</p>
      <p>{student.email}</p>
    </Card>
  );
}

export default StudentItem;
