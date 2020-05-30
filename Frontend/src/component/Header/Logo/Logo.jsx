import React from 'react';
import classes from  './Logo.module.css';
import logo from './Logo.png';
const Logo=()=>{
    return(
        <div className={classes.logo}> 
            <img src={logo} alt='logo'/>
        </div>
    );
}
export default Logo;