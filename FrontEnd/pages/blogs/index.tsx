import React, {FC} from 'react';
import Layout from 'components/global/layout';
import './styles.scss';

interface IProps {};

export const Blogs: FC<IProps> = () => (
  <Layout title="Blogs" description="This is the Blogs Page">
    <div className="blogs-page">
      <p>
        This is the <strong>Blogs</strong> page
      </p>
    </div>
  </Layout>
);

export default Blogs;
