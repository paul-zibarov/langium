import React from 'react';
import classes from './CountNewWords.module.css';

const CountNewWords=()=>{
    return(
        <nav className={classes.countNewWords}> 
        <div className={classes.header}>Сьогодні доданих слів:</div>
        <div className={classes.box}></div>
        </nav>
    );
}
export default CountNewWords;