import React from 'react';
import classes from '../LoginPage/LoginPage.module.css';
import layer1 from './Layer1.png';
import layer2 from './Layer2.png';
import logo from './Logo.png';
import { withAuth } from '../Auth/Auth';
import { Redirect, NavLink } from 'react-router-dom';

export default  withAuth(({isAuthorized, authorize})=>
  isAuthorized ? (<Redirect to='/langium'/>):(
         <div className={classes.container}>
            <img className={classes.logo} src={logo}/>
            <img className={classes.layer1} src={layer1}/>
            <img className={classes.layer2} src={layer2}/>
          <form className={classes.loginForm}>
          <div>
            <input className={classes.inpt1} placeholder={'Login: '}/></div>
          <div>
            <input className={classes.inpt2} placeholder={'Password: '}/></div>
        <button className={classes.login} onClick={authorize}>Увійти</button>
        </form>
        <NavLink to='/registration-page'>
        <div className={classes.registration}>Немає акаунту? Зареєструйся!</div>
       </NavLink>
       </div>
  ));