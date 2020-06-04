import React from 'react';
import classes from  './HiUser.module.css';
import user from './user.png';
const HiUser=(props)=>{
    return(
        <div className={classes.hiUser}> 
            <img src= {user}/> 
             <h4>Привіт, {props.userName}</h4>
        </div>
    );
}
export default HiUser;