import React from 'react';

const profileData={
    velopert:{
        name: '김민준',
        description:
        'Frontend Engineer @ Laftel Inc. 개발자'
    },
    gildong:{
        name: '홍길동',
        description:
        '동에 번쩍 서에 번쩍'
    }
};

const Profile = ({match})=>{
    const {username}=match.params;
    const profile=profileData[username];
    if(!profile){
        return <div>존재하지 않는 유저 입니다.</div>
    }
    return(
        <div>
            <h3>
                {username}({profile.name})
            </h3>
            <p>{profile.description}</p>
        </div>
    );
};
export default Profile;