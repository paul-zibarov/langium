import React from 'react';
import classes from './Level.module.css';
import logo from '../../LoginPage/Logo.png';
import { NavLink, Redirect } from 'react-router-dom';
import { withAuth } from '../../Auth/Auth';

export const Level=()=>{
    return(
        <Level/>
    )
}

export default withAuth(({isAuthorized, authorize})=>
    isAuthorized ? (<Redirect to='/langium'/>) : 
    (       <div className={classes.container}>
            <img className={classes.logo} src={logo}/>
            <div className={classes.header}>ОБЕРІТЬ ВАШ РІВЕНЬ АНГЛІЙСЬКОЇ!</div>
        
          <div>
            <button className={classes.beginer}>Новачок</button></div>
          <div>
          <div>
            <button className={classes.medium}>Трохи знаю, але хочу знати більше</button></div>
          </div> 
          <div>
           <button className={classes.advanced} >Знаю непогано</button>
          </div>
        <NavLink to='/registration-page'>
        <button className={classes.back}>Назад</button>
        </NavLink>
        <NavLink to='/langium'>
        <button className={classes.continue} onClick={authorize}>Продовжити</button>
        </NavLink> 
        
        </div>
     ));
  