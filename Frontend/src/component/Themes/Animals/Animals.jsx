import React from 'react';
import classes from  './Animals.module.css';
import animals from './animals.png';
const Animals=()=>{
    return(
        <div className={classes.animals}> 
       <img src={animals}/>
         <h2>Тварини</h2>
          
        </div>
    );
}
export default Animals;