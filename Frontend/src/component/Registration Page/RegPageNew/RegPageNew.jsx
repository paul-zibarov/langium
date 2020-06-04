import React from 'react';
import classes from './RegPageNew.module.css';
import logo from '../../LoginPage/Logo.png';
import { NavLink, Redirect } from 'react-router-dom';
import { withAuth } from '../../Auth/Auth';

export const RegPageNew=()=>{
   return(
      <RegPageNew/>
   )
}

 export default  withAuth(({isAuthorized, authorize})=>
 isAuthorized ? (<Redirect to='/langium'/>) : 
 (         <div className={classes.container}>
            <img className={classes.logo} src={logo}/>
            <div className={classes.header}>СТВОРІТЬ ВАШ ОБЛІКОВИЙ ЗАПИС У LANGIUM!</div>
             <form className={classes.regForm}>
          <div>
            <input className={classes.eMail} placeholder={"E-mail: "}/></div>
         <div>
            <input className={classes.password} placeholder={"Password: "}/></div>
        
        <NavLink to='/langium'>
        <button className={classes.registration} onClick={authorize}>Зареєструватись</button>
        </NavLink> 
        </form>
       </div>
  ));
 