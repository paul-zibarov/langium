import React from 'react';
import classes from  './Travell.module.css';
import travell from './travelling.png';
const Travell=()=>{
    return(
        <nav className={classes.travell}> 
       <img src={travell}/>
         <h2>Подорожуй вільно!</h2>
          
        </nav>
    );
}
export default Travell;