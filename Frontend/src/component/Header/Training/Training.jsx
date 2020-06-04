import React from 'react';
import classes from  './Training.module.css';
import Modal from 'react-modal';
import { NavLink } from 'react-router-dom';

const  Training =(props)=>{
 
    let subtitle;
    const [modalIsOpen,setIsOpen] = React.useState(false);
    const [tr1ModalIsOpen, tr1SetIsOpen] = React.useState(false);
    const [tr2ModalIsOpen, tr2SetIsOpen] = React.useState(false);
    const [tr3ModalIsOpen, tr3SetIsOpen] = React.useState(false);
    
    /*MAIN_MODAL*/
    function openModal() {
      setIsOpen(true);
    }
  
    function closeModal(){
      setIsOpen(false);
    }
    /*TR1_MODAL*/
    function tr1OpenModal() {
      tr1SetIsOpen(true);
    }
  
    function tr1CloseModal(){
      tr1SetIsOpen(false);
    }

    /*TR2_MODAL*/
    function tr2OpenModal() {
      tr2SetIsOpen(true);
    }
  
    function tr2CloseModal(){
      tr2SetIsOpen(false);
    }

    /*TR3_MODAL*/
    function tr3OpenModal() {
      tr3SetIsOpen(true);
    }
  
    function tr3CloseModal(){
      tr3SetIsOpen(false);
    }
    
      return (
        <div className={classes.training}>
          <button className={classes.button} onClick={openModal} >
              <h4 className={classes.h4}>Тренування</h4>
              <hr className={classes.hr}/>
              </button> 
          
          <Modal 
            className={classes.modal}
            isOpen={modalIsOpen}
            onRequestClose={closeModal}
            style={classes.modal}>

            <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
            <div className={classes.modalHeader}>
             <div className={classes.headerText}>Оберіть тип тренування</div>
            </div>

            <div>
           <NavLink to='/langium/training/eng-translate'>
           <button className={classes.checkTranslate} onClick={tr1OpenModal}>Тренування 1</button> 
           </NavLink>

            <Modal
                className={classes.tr1Modal}
                isOpen={tr1ModalIsOpen}          
                onClose={tr1CloseModal} 
                onRequestClose={tr1CloseModal}> 
                
                <div className={classes.Tr1modalHeader}>
                <div className={classes.headerTextTr1}>Надрукуйте переклад</div>
                  <form className={classes.enterTranslate}>
                  <hr className={classes.hr1}/>
                  <button className={classes.okTR1} ></button> 
                <div>
                  <input className={classes.textTR1}/>
                </div></form>
                </div>
              </Modal>
              </div>

           <div>
             <NavLink to='/langium/training/ukr-translate'>
            <button className={classes.engTranslate} onClick={tr2OpenModal}>Тренування 2</button> 
              </NavLink>

              <Modal
                className={classes.tr2Modal}
                isOpen={tr2ModalIsOpen}          
                onClose={tr2CloseModal} 
                onRequestClose={tr2CloseModal}> 
                
                  <div className={classes.Tr2modalHeader}>
                  <div className={classes.headerTextTr2}>Надрукуйте переклад</div>
                  <form className={classes.enterTranslate}>
                  <hr className={classes.hr2}/>
                  <button className={classes.okTR2} ></button> 
                  <div>
                  <input className={classes.textTR2}/>
                  </div>
                  </form>
                  </div>
              </Modal>
           </div>
      
           <div>
          <NavLink to='/langium/training/check-translate'>
           <button className={classes.ukrTranslate} onClick={tr3OpenModal}>Тренування 3</button> 
           </NavLink>

           <Modal
                className={classes.tr3Modal}
                isOpen={tr3ModalIsOpen}          
                onClose={tr3CloseModal} 
                onRequestClose={tr3CloseModal}> 
                
                  <div className={classes.Tr3modalHeader}>
                  <div className={classes.headerTextTr3}>Оберіть переклад</div>
                  <hr className={classes.hr3}/>
                  <div>
                  <button className={classes.var1} >*варіант 1*</button> 
                  </div>
                  <div>
                  <button className={classes.var2} >*варіант 2*</button> 
                  </div>
                  <div>
                  <button className={classes.var3} >*варіант 3*</button> 
                  </div>
                  <div>
                  <button className={classes.var4} >*варіант 4*</button> 
                  </div>                  
                  </div>
              </Modal>
           </div>
           
           <NavLink to='/langium/training/fold-letters'>
           <div>
           <button className={classes.foldLett} >Тренування 4</button> 
           </div>
           </NavLink>
          </Modal>
        </div>



      );
  }

export default Training;