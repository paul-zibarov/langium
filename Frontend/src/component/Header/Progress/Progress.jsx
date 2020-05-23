import React from 'react';
import classes from  './Progress.module.css';
import Modal from 'react-modal';
import { render } from '@testing-library/react';

function Progress(){
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
      render()
      {
      return (
        <div>
          <button className={classes.button} onClick={openModal} >
              <hr className={classes.hr}/>
              </button> 
          
          <Modal className={classes.modal}
            isOpen={modalIsOpen}
            onAfterOpen={afterOpenModal}
            onRequestClose={closeModal}
            style={classes.modal}
           >
            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
           
   
          </Modal>
        </div>
      );
  }
}

export default Progress;