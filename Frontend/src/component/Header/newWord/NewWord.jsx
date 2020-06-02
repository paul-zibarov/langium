import React from 'react';
import classes from  './NewWord.module.css';

const NewWord=(props)=>{
  return(
    <div className={classes.item}>
      {props.word} {props.translate}
    </div>
  );
}
export default NewWord;