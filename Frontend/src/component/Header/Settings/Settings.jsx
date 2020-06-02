import React from 'react';
import classes from  './Settings.module.css';
import Modal from 'react-modal';
import setting from './setting.png'
import { NavLink, Redirect } from 'react-router-dom';

function Settings(autorize){
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
            style={classes.modal}>

            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
            <img src={setting} className={classes.sett}/> 
            <div className={classes.modalHeader}>
              <div className={classes.headerText}>Налаштування</div>
            </div>
            <hr className={classes.hr2}></hr>
            <NavLink to='/login'>
            <div>
            <button className={classes.exit} onClick={<Redirect to='/login'/>}>Вихід</button>
            </div>
            </NavLink>
             <div>
            <NavLink to='/langium'>
            <button className={classes.return} onClick={closeModal}>Повернутися назад</button>
            </NavLink>
            </div> 
          </Modal>
        </div>



      );
  }

export default Settings;