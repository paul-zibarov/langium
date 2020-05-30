import React from 'react';
import './App.css';
import Header from './component/Header/Header';
import Rating from './component/Rating/Rating';
import Themes from './component/Themes/Themes';
import { BrowserRouter, Route } from 'react-router-dom';
import NewWords from './component/Header/NewWords/NewWords';
import NavBar from './component/NavBar/NavBar';
import Training from './component/Header/Training/Training';
import Progress from './component/Header/Progress/Progress';
import HiUser from './component/Header/HiUser/HiUser';
import Settings from './component/Header/Settings/Settings';
import Vocabulary from './component/Header/Vocabulary/Vocabulary';

debugger;
const App=(props)=> {
  return (
    <BrowserRouter>
    <div className="app-wrapper">
      <Header store={props.store}/>
      <Rating store={props.store}/>
      <NavBar store={props.store}/>
    </div>
    </BrowserRouter>
  );
}

export default App;
