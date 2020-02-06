/* eslint-disable no-undef */

import React from 'react';
import toJson from 'enzyme-to-json';
import { shallow } from 'enzyme';
import { StudentItem } from '@root/components/studentItem';

const defaultComponent = <StudentItem t={() => {}} />;

test('StudentItem is rendered', () => {
  expect(toJson(shallow(defaultComponent))).toMatchSnapshot();
});

/* eslint-enable no-undef */
