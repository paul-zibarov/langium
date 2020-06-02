import React from 'react';
import './App.css';
import Header from './component/Header/Header';
import Rating from './component/Rating/Rating';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import NavBar from './component/NavBar/NavBar';
import LoginPage from './component/LoginPage/LoginPage';
import { PrivateRoute } from './component/Auth/PrivatePoute';
import { AuthProvider } from './component/Auth/Auth';
import Registration from './component/Registration Page/registration';
import Level from './component/Registration Page/LevelOfKnowladge/Level';

debugger;
const App=(props)=> {
  return (
    <BrowserRouter>
    <AuthProvider>
    <Switch>
    <div className="app-wrapper">
        <Route path='/registration-page' component={Registration}/>
        <Route path='/choise-your-level' component={Level}/>
        <PrivateRoute  path='/langium/new-words' component={Header}/>
        <PrivateRoute  path='/langium/vocabulary' component={Header}/>
        <PrivateRoute  path='/langium/training' component={Header}/>
        <PrivateRoute  path='/langium/progress' component={Header}/>
        <PrivateRoute  path='/langium/hiuser' component={Header}/>
        <PrivateRoute  path='/langium/setting' component={Header}/>
        <PrivateRoute  path='/langium' component={Header}/>
        <PrivateRoute  path='/langium' component={Rating}/>
        <PrivateRoute  path='/langium' component={NavBar}/>
        <Route  path='/login' component={LoginPage}/> 
    </div>
    </Switch>
    </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
