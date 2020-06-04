import React from 'react';
import classes from './registration.module.css';
import logo from '../LoginPage/Logo.png';
import { NavLink } from 'react-router-dom';

 const  Registration =()=>{
    return(
         <div className={classes.container}>
            <img className={classes.logo} src={logo}/>
            <div className={classes.header}>СТВОРІТЬ ВАШЕ ІМ'Я У LANGIUM!</div>
             <form className={classes.regForm}>
          <div>
            <input className={classes.inpt1} placeholder={"Ім'я: "}/></div>
        <NavLink to='/login'>
        <button className={classes.back}>Назад</button>
        </NavLink>
        <NavLink to='/choise-your-level'>
        <button className={classes.continue} >Продовжити</button>
        </NavLink> 
        </form>
       </div>
  )};
  export default Registration;