import React from 'react';
import classes from  './Header.module.css';
import Logo from './Logo/Logo';
import Vocabulary from './Vocabulary/Vocabulary';
import Training from './Training/Training';
import HiUser from './HiUser/HiUser';
import NewWords from './NewWords/NewWords';
import Settings from './Settings/Settings';
import Progress from './Progress/Progress';
import { NavLink } from 'react-router-dom';

const Header=(props)=>{
    return(
        <div className={classes.header}> 
           <Logo/>
           <NavLink to ='/new-words'><NewWords/></NavLink>
           <NavLink to ='/vocabulary'><Vocabulary/></NavLink>
           <NavLink to ='/training'><Training/></NavLink>
           <NavLink to ='/progress'><Progress/></NavLink>
           <NavLink to ='/hiuser'><HiUser/></NavLink>
           <NavLink to ='/settings'><Settings/></NavLink>
           
          
                       
        </div>
    );
}
export default Header;