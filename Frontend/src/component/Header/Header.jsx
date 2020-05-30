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
           <NavLink to='/langium/new-words'><NewWords store={props.store}/></NavLink>
            <NavLink to='/langium/vocabulary'><Vocabulary /></NavLink>
            <NavLink to='/langium/training'><Training /></NavLink>
            <NavLink to='/langium/progress'><Progress /></NavLink>
            <NavLink to='/langium/hiuser'><HiUser /></NavLink>
            <NavLink to='/langium/settings'><Settings /></NavLink>
                       
        </div>
    );
}
export default Header;