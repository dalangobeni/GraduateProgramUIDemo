import { createContext } from 'react';

interface ICourseContext {}

export const defaultCourseContext: ICourseContext = {

};

export const CourseContext = createContext<ICourseContext>(defaultCourseContext);