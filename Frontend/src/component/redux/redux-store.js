import { createStore, combineReducers } from "redux";
import newWordsReduser from "./newWordsReducer";


let redusers=combineReducers( {
    newWordsReduser: newWordsReduser,
    
});

let store = createStore(redusers);

export default store;