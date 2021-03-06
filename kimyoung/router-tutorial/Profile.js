import React from 'react';

const profileData = {
    velopert : {
        name : '김민준',
        description : 
        `descrpiton`
    },
    gildong : {
        name : `홍길동`,
        description : `des`
    }
};

const Profile = ({match}) =>{
    const {username} = match.params;
    const profile = profileData[username];

    if(!profile){
        return <div>존재하지 않는 유저입니다.</div>;
    }
    return (
        <div>
            <h3>
                {username}({profile.name})
            </h3>
            <p>{profile.description}</p>
        </div>
    );
};

export default Profile;