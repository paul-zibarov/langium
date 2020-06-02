import React from 'react';
import classes from  './Vocabulary.module.css';
import Modal from 'react-modal';
import MySet from './mySets/mySets';
import { NavLink } from 'react-router-dom';


const Vocabulary=(props)=>{
  debugger;
 
  let subtitle;
  const [modalIsOpen,setIsOpen] = React.useState(false);
  const [addWordModalIsOpen, addWordSetIsOpen] = React.useState(false);
  const [addCategoryModalIsOpen, addCategorySetIsOpen] = React.useState(false);
  
  //MAIN_MODAL
  function openModal() {
    setIsOpen(true);
  }
  
  function afterOpenModal() { 
  }

  function closeModal(){
    setIsOpen(false);
  }
  
  // ADD_WORD_TO_CATEGORY_MODAL
  function openAddWordModal(){
    addWordSetIsOpen(true);
    
  }
 /* function afterAddWordOpenModal() { 
    addCategorySetIsOpen(false);
  }*/
  function closeAddWordModal(){
    addWordSetIsOpen(false);
    

  }

  // ADD_CATEGORY_MODAL
  function openAddCategoryModal(){
    addCategorySetIsOpen(true);
  }
  /*function afterAddCategoryOpenModal() { 
    addWordSetIsOpen(false);
  }*/
  function closeAddCategoryModal(){
     addCategorySetIsOpen(false);
     

  }

  function listOfWordsOfCategory(){
  return('listOfWords1');
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

          <div className={classes.nameOfSet}>
          <h3 className={classes.mySets}>Мої набори</h3>
          <hr className={classes.hr1}/>
           <div className={classes.category}>
             <div>
             <MySet id={props.category.id} key={props.activeCategory}/>
             {props.category.map((category, index)=>(
               <div>
                 <NavLink to={'/langium/vocabulary/'+category.name} >
                  <button isActive={true} className={classes.itemOfList} key={index} 
                  onClick={listOfWordsOfCategory}>{category.name}</button>
                  </NavLink>
                   </div>
             ))}
          </div>
           </div>
          <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
          <div>
          <NavLink to='/langium/vocabulary/add-category'>
         <button className={classes.addCategory} onClick={openAddCategoryModal}></button>           
         </NavLink>
          <Modal
           className={classes.addCategoryModal}
          isOpen={addCategoryModalIsOpen}
          onRequestClose={closeAddCategoryModal} 
          >

          <div>
          <form className={classes.addCategoryForm}>          
            <div className={classes.addcategory}>Нова категорія</div>
            <div>
            <NavLink to='/langium/vocabulary'>
              <button className={classes.closeMod1} onClick={closeAddCategoryModal}></button>
            </NavLink>
            </div>
            <div>
              <input className={classes.name} placeholder={'Назва категорії:'}></input>
            </div>
            <div>
              <input className={classes.description} placeholder={'Опис:'}></input>
            </div>
            <div>
              <button className={classes.addToList}>Додати</button>
              </div>
          </form>
          <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
          </div>
           </Modal>
          </div>
         <button className={classes.modalHeader}>
          <div>Слова поточного набору:</div>
          </button>
          <div className={classes.wordsOfCurrentCat}>

             <div  className={classes.wordInList}>
             <MySet id={props.listOfWordsAnimal.id} word={props.listOfWordsAnimal.word} translate={props.listOfWordsAnimal.translate}/>
             {props.listOfWordsAnimal.map((words, index)=>(
               <div>
                  <ul className={classes.ul} key={index}>{words.word} - {words.translate}</ul>
                  <hr className={classes.hrInList}/>
                </div>
             ))}
         </div>

          <vl className={classes.vl}/>
          </div>
          <div>
          <NavLink to='/langium/vocabulary/add-word'>
            <button className={classes.addWordToCategory} onClick={openAddWordModal}></button>
          </NavLink>

          <Modal
           className={classes.addWordToCategoryModal}
          isOpen={addWordModalIsOpen}          
          onClose={closeAddWordModal} 
          onRequestClose={closeAddWordModal}>
          

          <div>
          <form className={classes.addWordForm}>          
            <div className={classes.addWord}>Нове слово</div>
            <div>
              <NavLink to='/langium/vocabulary'>
              <button className={classes.closeMod} onClick={closeAddWordModal}></button>
              </NavLink>

            </div>
            <div>
              <input className={classes.word} placeholder={'Слово:'}></input>
            </div>
            <div>
              <input className={classes.translate} placeholder={'Переклад:'}></input>
            </div>
            <div>
              <button className={classes.addToCategory}>Додати</button>
              </div>
          </form>
          </div>
           </Modal>
           
          </div>
          <vl className={classes.vl}/>
          <h2 ref={_subtitle => (subtitle = _subtitle)}></h2>
          </div>
        </Modal>
      </div>
    );
}

export default Vocabulary;