import React from 'react';
import classes from  './Food.module.css';
import food from './food.png';
const Food=()=>{
    return(
        <div className={classes.food}> 
       <img src={food}/>
         <h2>Їжа</h2>
          
        </div>
    );
}
export default Food;