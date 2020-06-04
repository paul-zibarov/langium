import React from 'react';
import classes from  './Business.module.css';
import business from './business.png';
const Business=()=>{
    return(
        <div className={classes.business}> 
       <img src={business}/>
         <h2>Бізнес</h2>
          
        </div>
    );
}
export default Business;