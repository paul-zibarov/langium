import React from 'react';
import classes from  './TrainingFoldTheLetters.module.css';
import Modal from 'react-modal';

const  TrainingFoldTheLetters =(props)=>{
    //let elll= props.words.map(el => <Training id={el.id} word={el.word} translate={el.translate}/>)
    debugger;
    let subtitle;
    const [modalIsOpen,setIsOpen] = React.useState(false);
    
    function openModal() {
      setIsOpen(true);
    }
  
    function afterOpenModal() {
  
      subtitle.style.color = '#ffffff';
    }
  
    function closeModal(){
      setIsOpen(false);
    }
      return (
        <div className={classes.training}>
          <button className={classes.button} onClick={openModal} >
              <h4 className={classes.h4}>Тренування</h4>
              <hr className={classes.hr}/>
              </button> 
          
          <Modal className={classes.modal}
            isOpen={modalIsOpen}
            onAfterOpen={afterOpenModal}
            onRequestClose={closeModal}
            style={classes.modal}>

            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
            <div className={classes.modalHeader}>
             <div className={classes.headerText}>Надрукуйте переклад</div>
            </div>
               <div>{props.words}</div>
            <form className={classes.enterTranslate}></form>
            <button className={classes.ok} ></button> 
           <div>
            <input className={classes.text}/>
           </div>
          </Modal>
        </div>



      );
  }

export default TrainingFoldTheLetters;