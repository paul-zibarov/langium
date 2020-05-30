import React from 'react';
import classes from '../LoginPage/LoginPage.module.css';
import layer1 from './Layer1.png';
import layer2 from './Layer2.png';
import logo from './Logo.png';
import { reduxForm } from 'redux-form';


const LoginForm=(props)=>{
     return(
         <div className={classes.container}>
            <img className={classes.logo} src={logo}/>
            <img className={classes.layer1} src={layer1}/>
            <img className={classes.layer2} src={layer2}/>
          <form className={classes.loginForm}>
          <div>
            <input className={classes.inpt1} placeholder={'Login'}/></div>
          <div>
            <input className={classes.inpt2} placeholder={'Password'}/></div>
        <button className={classes.login}>Увійти</button>
        </form>
        </div>
     );
   }
 
  const LoginPage =(props)=>{
    return(
    <div classes={classes.login}>
      <LoginForm/>
    </div>
     ) }

 
 export default LoginPage;