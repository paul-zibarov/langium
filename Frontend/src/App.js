import React from 'react';
import './App.css';
import Header from './component/Header/Header';
import Rating from './component/Rating/Rating';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import NavBar from './component/NavBar/NavBar';
import LoginPage from './component/LoginPage/LoginPage';
import { PrivateRoute } from './component/Auth/PrivatePoute';
import { AuthProvider } from './component/Auth/Auth';

debugger;
const App=(props)=> {
  return (
    <BrowserRouter>
    <AuthProvider>
    <Switch>
    <div className="app-wrapper">
      <PrivateRoute  path='/langium/new-words' component={Header}/>
        <PrivateRoute  path='/langium/vocabulary' component={Header}/>
        <PrivateRoute  path='/langium/training' component={Header}/>
        <PrivateRoute  path='/langium/progress' component={Header}/>
        <PrivateRoute  path='/langium/hiuser' component={Header}/>
        <PrivateRoute  path='/langium/setting' component={Header}/>
        <PrivateRoute  path='/langium' component={Header}/>
        <PrivateRoute  path='/langium' component={Rating}/>
        <PrivateRoute  path='/langium' component={NavBar}/>
        <Route exact path='/login' component={LoginPage}/> 
    </div>
    </Switch>
    </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
