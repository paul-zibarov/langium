import React from 'react';
import classes from  './Training.module.css';
import Modal from 'react-modal';

function TrainingEngTranslate(){
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
          </button> 
          
          <Modal className={classes.modal2}
            isOpen={modalIsOpen}
            onAfterOpen={afterOpenModal}
            onRequestClose={closeModal}
            style={classes.modal2}
           >
            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
            <div className={classes.modalHeader}>
              <div className={classes.headerText}>Оберіть переклад</div>
            </div>
            <textarea className={classes.textarea}>
            <button className={classes.button1} >
            <div className={classes.cls}>translate</div>   
           </button> 
           <button className={classes.button2}>
            <div className={classes.ok}>translate</div>
            </button>
            <button className={classes.button3} >
            <div className={classes.cls}>translate</div>   
           </button> 
           <button className={classes.button4} >
            <div className={classes.cls}>translate</div>   
           </button> 
           </textarea>
          </Modal>
        </div>



      );
  }

export default TrainingEngTranslate;