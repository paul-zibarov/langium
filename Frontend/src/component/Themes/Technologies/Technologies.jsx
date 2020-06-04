import React from 'react';
import classes from  './Technologies.module.css';
import technologies from './technologies.png';
const Technologies=()=>{
    return(
        <div className={classes.technologies}> 
       <img src={technologies}/>
        <h2>Інтернет та технології</h2> 
          
        </div>
    );
}
export default Technologies;