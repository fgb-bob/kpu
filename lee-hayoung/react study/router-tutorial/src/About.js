import React from 'react';
import qs from 'qs';
import { Link, NavLink } from 'react-router-dom';

const About = ({location}) => {
  const query =qs.parse(location.search,{
    ignoreQueryPrefix:true
  });
  const detail = query.detail === 'true';


  return (
    <div>
      <h1>소개</h1>
      <p>이 프로젝트는 리액트 라우터 기초를 실습해보는 예제 프로젝트랍니다.</p>
      {detail && <div>
        <p>추가적인 정보가 어쩌고 저쩌고..</p>
        <Link to="/about">돌아가기</Link>
      </div>}
      
      <NavLink to="/about?detail=true"
      activeStyle={{visibility:"visible"}}>추가정보</NavLink>
    </div>
  );
};

export default About;