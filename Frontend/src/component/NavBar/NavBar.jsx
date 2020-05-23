import React from 'react';
import classes from './NavBar.module.css';
import CountNewWords from '../CountNewWords/CountNewWords';
import Themes from '../Themes/Themes';
import AllWords from '../AllWords/AllWords';


const NavBar=()=>{
    return(
        <nav className={classes.navBar}>
        <div> 
        <CountNewWords/>
        <Themes/>
        <AllWords/>
        </div> 
        </nav>
    );
}
export default NavBar;