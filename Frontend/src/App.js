import React from 'react';
import './App.css';
import Header from './component/Header/Header';
import Rating from './component/Rating/Rating';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import NavBar from './component/NavBar/NavBar';
import LoginPage from './component/LoginPage/LoginPage';

debugger;
const App=(props)=> {
  return (
    <BrowserRouter>
    <Switch>
    <div className="app-wrapper">
        <Route  path='/langium/new-words' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium/vocabulary' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium/training' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium/progress' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium/hiuser' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium/setting' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium' render={()=><Header store={props.store}/>}/>
        <Route  path='/langium' render={()=><Rating/>}/>
        <Route  path='/langium' render={()=><NavBar/>}/>
        <Route exact path='/login' component={LoginPage}/> 
    </div>
    </Switch>
    </BrowserRouter>
  );
}

export default App;
