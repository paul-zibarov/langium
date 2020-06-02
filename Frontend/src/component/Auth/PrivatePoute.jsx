import React from 'react';
import {withAuth} from './Auth';
import { Route, Redirect } from 'react-router-dom';

export const PrivateRoute = withAuth(
    ({component: RouteComponent, isAuthorised, ...rest})=>(
    <Route {...rest} render={routeProps=>
        isAuthorised ?( <RouteComponent {...routeProps}/>): 
       ( <Redirect to= {'/login'}/>
       )
    }
        />
));
