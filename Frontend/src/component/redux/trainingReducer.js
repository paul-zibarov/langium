const KNOW= 'KNOW';
const DONT_KNOW= 'DONT-KNOW';


let initialState={
  newWords:[
    {id:1, word:'Apple', translate:'Яблуко', transcription: '[ˈapəl]'},
    {id:2, word:'Car', translate:'Автомобіль', transcription: '[ˈkɑː]'},
    {id:3, word:'Tree', translate:'Дерево', transcription: '[ˈtriː]'},
    {id:4, word:'Box', translate:'Коробка', transcription: '[ˈbɒks]'},
    {id:5, word:'House', translate:'Дім', transcription: '[ˈhaʊz]'},

]
}

const trainingReducer=(state=initialState, action)=>{
     switch (action.type){
       case KNOW:
        state.newMessageBody=action.newMessage;
        return state;

      case DONT_KNOW:
       let body = state.newMessageBody;
       state.newMessageBody='';
       state.messagesData.push({id:4,message: body})
  return state;

  default: 
  return state;
      }
  
}
export const knowActionCreator=()=>{( {type: KNOW})}

export const dontKnowActionCreator=()=> {({type: DONT_KNOW, body: body})}
    
export default trainingReducer;