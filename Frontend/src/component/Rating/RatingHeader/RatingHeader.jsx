import React from 'react';
import classes from  './RatingHeader.module.css';

const RatingHeader=()=>{
    return(
        <div className={classes.ratingHeader}> 
          <h1>Рейтинг</h1>
        </div>
    );
}
export default RatingHeader;