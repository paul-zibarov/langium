import React from 'react';
import classes from  './Header.module.css';
import Logo from './Logo/Logo';
import Vocabulary from './Vocabulary/Vocabulary';
import Training from './Training/Training';
import HiUser from './HiUser/HiUser';
import NewWords from './NewWords/NewWords';
import Settings from './Settings/Settings';
import Progress from './Progress/Progress';



const Header=(props)=>{
    return(
        <div className={classes.header}> 
           <Logo/>
           <NewWords store={props.store}/>
           <Vocabulary store={props.store}/>
           <Training store={props.store}/>
           <Progress store={props.store}/>
           <HiUser store={props.store}/>
           <Settings/>
          
                       
        </div>
    );
}
export default Header;