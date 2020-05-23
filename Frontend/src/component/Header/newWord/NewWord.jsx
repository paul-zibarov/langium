import React from 'react';
import classes from  './NewWords.module.css';
import { NavLink } from 'react-router-dom';

const NewWord=(props)=>{
  return(
    <div className={classes.item}>
      <NavLink to ={'/newWords/'}> {props.name}</NavLink>
    </div>
  );
}
export default NewWord;