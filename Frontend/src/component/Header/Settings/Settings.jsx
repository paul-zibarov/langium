import React from 'react';
import classes from  './Settings.module.css';
import Modal from 'react-modal';
import setting from './setting.png'

function Settings(){
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
            <hr className={classes.hr}/>
            </button> 
          
          <Modal className={classes.modal}
            isOpen={modalIsOpen}
            onAfterOpen={afterOpenModal}
            onRequestClose={closeModal}
            style={classes.modal}
            
          >
            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
            <img src={setting} className={classes.sett}/> 
            <div className={classes.modalHeader}>
              <div className={classes.headerText}>Налаштування</div>
            </div>
            <hr className={classes.hr2}></hr>
            <button className={classes.button1} >
            <div className={classes.cls}>Видалити акаунт</div>   
           </button> 
           <button className={classes.button2}>
            <div className={classes.ok}>Вийти з налаштувань</div>
            </button>
          </Modal>
        </div>



      );
  }

export default Settings;