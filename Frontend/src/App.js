import React from 'react';
import './App.css';
import Header from './component/Header/Header';
import Rating from './component/Rating/Rating';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import NavBar from './component/NavBar/NavBar';
import LoginPage from './component/LoginPage/LoginPage';
import { AuthProvider } from './component/Auth/Auth';
import { PrivateRoute } from './component/Auth/PrivatePoute';

const App=(props)=> {
  return (
    <AuthProvider>
    <BrowserRouter>
    <Switch>
    <div className="app-wrapper">
        <PrivateRoute  path='/langium/new-words' render={()=><Header />}/>
        <Route  path='/langium/vocabulary' render={()=><Header />}/>
        <Route  path='/langium/training' render={()=><Header />}/>
        <Route  path='/langium/progress' render={()=><Header />}/>
        <Route  path='/langium/hiuser' render={()=><Header />}/>
        <Route  path='/langium/setting' render={()=><Header />}/>
        <Route  path='/langium' render={()=><Header />}/>
        <Route  path='/langium' render={()=><Rating/>}/>
        <Route  path='/langium' render={()=><NavBar/>}/>
        <Route exact path='/login' render={()=><LoginPage/>}/> 
    </div>
    </Switch>
    </BrowserRouter>
    </AuthProvider>
  );
}

export default App;
