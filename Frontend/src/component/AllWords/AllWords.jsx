import React from 'react';
import classes from './AllWords.module.css';
import { render } from '@testing-library/react';

const AllWords=()=>{
    render()
    {
    return(
        <nav className={classes.allWords}> 
        <div className={classes.header}>Всього слів на вивченні:</div>
        <div className={classes.box}></div>
        <button className={classes.button}>Вчити</button>
        </nav>
    );
}
}
export default AllWords;