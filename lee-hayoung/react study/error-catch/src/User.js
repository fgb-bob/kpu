import React from 'react';

/*
function User({user}){
    if(!user){
        return null;
    } //user값이 존재하지않으면  null리턴 : null checking

    return(
        <div>
            <div>
                <b>ID</b>:{user.id}
            </div>
            <div>
                <b>Username:</b> {user.username}
            </div>
        </div>
    );
}*/

function User({ user }) {
    // if (!user) {
    //   return null;
    // }
  
    return (
      <div>
        <div>
          <b>ID</b>: {user.id}
        </div>
        <div>
          <b>Username:</b> {user.username}
        </div>
      </div>
    );
  }
  
  export default User;
