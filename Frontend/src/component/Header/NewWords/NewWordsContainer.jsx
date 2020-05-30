import React from 'react';
import { connect } from 'react-redux';
import NewWords from './NewWords';
import store from '../../redux/redux-store';

let mapStateToProps=(state)=>{
  return{
    words: state.NewWords.words
  }
}
let mapDispatchToProps=(dispatch)=>{
  return{
    knowWord: (wordId)
  }
}

export default connect (mapStateToProps, mapDispatchToProps) (NewWords);