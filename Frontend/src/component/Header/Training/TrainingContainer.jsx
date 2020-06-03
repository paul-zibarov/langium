import React from 'react';
import Training from './Training';
import Axios from 'axios';

class TrainingContainer  extends React.Component {
  constructor(props){
    super(props);
    this.state={
    words: [
    {id:1, word:'Apple', translate:'Яблуко'},
    {id:2, word:'House',  translate: 'Будинок'},
    {id:3, word:'Car',  translate: 'Авто'},
    {id:4, word:'Box',  translate: 'Коробка'},
    {id:5, word:'Flower',  translate: 'Квітка'}
    ]
    }
}
       
render() {
      return (
     <Training words={this.state.words}/>     
    );
  }
}

export default TrainingContainer;