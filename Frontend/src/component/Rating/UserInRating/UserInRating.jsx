import React from 'react';
import classes from  './UserInRating.module.css';


const UserInRating=(props)=>{
    return(
        <div className={classes.userInRating}> 
            <div className={classes.userNumb}>
              User {props.number}
            </div>
        </div>
    );
}
export default UserInRating;