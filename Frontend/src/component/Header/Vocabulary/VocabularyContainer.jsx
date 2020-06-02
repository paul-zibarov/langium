import React from 'react';
import Axios from 'axios';
import Vocabulary from './Vocabulary';

class VocabularyContainer  extends React.Component {
  constructor(props){
    super(props);
    this.state={
      category:[
      {id:1, name: 'Їжа'},
      {id:2, name:'Тварини'},
      {id:3, name:'Одяг'},
      {id:4, name:'Професії'},
      {id:5, name:'Наука'}
    ],
    listOfWordsAnimal:[
      {id:1, word:'Сat', translate:'Кіт'},
      {id:2, word:'Rabbit', translate:'Кролик'},
      {id:3, word:'Dog', translate:'Собака'},
      {id:4, word:'Sheep', translate:'Вівця'},
      {id:5, word:'Goat', translate:'Козел'},
      {id:4, word:'Sheep', translate:'Вівця'},
      {id:5, word:'Goat', translate:'Козел'}
    ],
      activeCategory: 0,
     }
  };
         
render() {
 
    return (
      <Vocabulary category={this.state.category} 
      listOfWordsAnimal={this.state.listOfWordsAnimal}
      activeCategory={this.state.activeCategory}
       />
    );
}
}
export default VocabularyContainer;