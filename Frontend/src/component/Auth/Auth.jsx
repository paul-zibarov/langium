import React from 'react';

const { Provider, Consumer: AuthConsumer} = React.createContext({
    isAuthorized: false
});

class AuthProvider extends React.Component{
    state={isAuthorized: false}

    authorize = ()=>{
        this.setState({isAuthorized: true})
    }
    render(){
        const {isAuthorized}= this.state;
        return(
            <Provider value={{isAuthorized, authorize: this.authorize}}>
                {this.props.children}
            </Provider>
        )
    }
}
export  function withAuth(WrappedComponent){
    return class AuthHOC extends React.Component{
        render(){
            return(
                <AuthConsumer>
                {contextProps => (
                    <WrappedComponent {...contextProps} {...this.props}/>
                )}
                </AuthConsumer>
            
            );
        }
    };
}

export  {AuthProvider};