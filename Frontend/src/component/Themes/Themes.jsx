import React from 'react';
import classes from  './Themes.module.css';
import ThemesHeader from './ThemesHeader/ThemesHeader';
import { NavLink } from 'react-router-dom';
import Food from './Food/Food';
import Animals from './Animals/Animals';
import Business from './Business/Business';
import Travell from './Travell/Travell';
import Technologies from './Technologies/Technologies';

const Themes=()=>{
    return(
        
        <nav className={classes.themes}> 
        <ThemesHeader/>  
        <hr className={classes.hr}/>
        <div className={classes.item}>
        <NavLink to="/langium/themes/food" activeClassName={classes.active}><Food/></NavLink>
        <NavLink to="/langium/themes/animals" activeClassName={classes.active}><Animals/></NavLink>
        <NavLink to="/langium/themes/newTheme" activeClassName={classes.active}><Animals/></NavLink>
        <NavLink to="/langium/themes/newTheme" activeClassName={classes.active}><Animals/></NavLink>
        <NavLink to="/langium/themes/newTheme" activeClassName={classes.active}><Animals/></NavLink>
       
        </div> 
        </nav>
      
    );
}
export default Themes;