import React from 'react';
import classes from  './ThemesHeader.module.css';

const ThemesHeader=()=>{
    return(
             <div className={classes.themeHeader}>
               <h1 className={classes.h1}>Популярні слова:</h1>
               <hr className={classes.hr}/>
            </div>
            );
}
export default ThemesHeader;

