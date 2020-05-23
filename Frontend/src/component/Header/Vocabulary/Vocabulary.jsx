import React from 'react';
import classes from  './Vocabulary.module.css';
import Modal from 'react-modal';


function Vocabulary(){
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
    return (
      <div className={classes.vocabulary}>
        <button className={classes.button} onClick={openModal} >
            <h4 className={classes.h4}>Словник</h4>
            <hr className={classes.hr}/>
            </button> 
        
        <Modal className={classes.modal}
          isOpen={modalIsOpen}
          onAfterOpen={afterOpenModal}
          onRequestClose={closeModal} >
          
          <h3 className={classes.h3}>Мої набори</h3>
          <hr className={classes.hr1}/>
          
          <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
          <button className={classes.learnNow} >
          <div className={classes.learnNow1}>Вчу зараз</div>   
         </button> 
         <button className={classes.modalHeader}>
          <div className={classes.ok}>Вчу зараз</div>
          </button>
          <vl className={classes.vl}/>
        </Modal>
      </div>
    );
}

export default Vocabulary;