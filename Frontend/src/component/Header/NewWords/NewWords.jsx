import React from 'react';
import classes from  './NewWords.module.css';
import Modal from 'react-modal';
import NewWord from '../newWord/NewWord';
import * as Axios from 'axios';


const  NewWords = (props) =>{
  Axios.get('https://social-network.samuraijs.com/api/1.0/users')
  .then(response =>{
    let list=response.data.items;
   debugger;
  })

  let newWordEl=props.words.map(el=> <NewWord id={el.id} word={el.word} translate={el.translate}/>)
 debugger;
  let subtitle;
  const [modalIsOpen,setIsOpen] = React.useState(false);
  function openModal() {
    setIsOpen(true);
  }

  function afterOpenModal() {

      }

  function closeModal(){
    setIsOpen(false);
  }
  let onLearnButtonCkick=()=>{
    alert('i know')
  }
  let onDontKnowButtonCkick=()=>{
    alert('jhjh');
  }
  

    return (
      <div>
        <button className={classes.button} onClick={openModal} >
            <h4> Нові слова</h4>
            <hr className={classes.hr}/>
            </button> 
        
        <Modal className={classes.modal}
          isOpen={modalIsOpen}
          onAfterOpen={afterOpenModal}
          onRequestClose={closeModal}>
          {newWordEl}
          <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
          <button className={classes.button2} onClick={onDontKnowButtonCkick}>
          <div className={classes.cls}>Вчити</div>   
         </button> 
        
         <button className={classes.button1} onClick={onLearnButtonCkick}>
          <div className={classes.ok}>Вже знаю</div>
          </button>
        </Modal>
      </div>
    );
}

export default NewWords;