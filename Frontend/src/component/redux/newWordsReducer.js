const KNOW= 'KNOW';
const DONT_KNOW= 'DONT-KNOW';
const SET_WORDS='SET-WORDS'

let initialState={
  newWords:[
    {id:1, word:'Apple'},
    {id:2, word:'House'},
    {id:3, word:'Car'},
    {id:4, word:'Box'},
    {id:5, word:'Flower'}
  ]
}
const newWordsReduser=(state=initialState, action)=>{
     switch (action.type){
       case KNOW:
        
        return state;

         case DONT_KNOW:
       state.newWords.push({id:4,name: 'Box'})
         return state;
          case SET_WORDS:
            return {...state, words: [...state.words, ...action.words]}

  default: 
  return state;
      }
  
}
export const knowActionCreator=()=>{( {type: KNOW})}

export const dontKnowActionCreator=()=> {({type: DONT_KNOW, name: name})}
 
export const setWordsActionCreator=()=>{({type: SET_WORDS, words})}
export default newWordsReduser;