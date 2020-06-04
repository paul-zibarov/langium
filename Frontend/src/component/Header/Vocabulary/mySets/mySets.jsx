import React from 'react';
import classes from  './mySets.module.css';

const MySet=(props)=>{
    return(
        <div className={classes.mySet}> 
            {props.name}
                       
        </div>
    );
}
export default MySet;