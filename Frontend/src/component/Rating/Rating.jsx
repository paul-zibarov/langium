import React from 'react';
import classes from  './Rating.module.css';
import RatingHeader from './RatingHeader/RatingHeader';
import UserInRating from './UserInRating/UserInRating';
import ShadowScroll from 'react-shadow-scroll';

const Rating=()=>{
    return(
        <div className={classes.rating}> 
         <RatingHeader/> 
         <h2>Стань першим!</h2>
         <ShadowScroll  >
         <hr className={classes.hr}/>  
         <table>
                  
         <tr>
             <td><UserInRating name='User' number='1'/></td>
         </tr>
         <tr>
             <td><UserInRating name='User' number='2'/></td>
        </tr>
         <tr>
            <td> <UserInRating name='User' number='3'/></td>
         </tr>
         <tr>
             <td><UserInRating name='User' number='4'/></td>
             </tr>
         <tr>
             <td><UserInRating name='User' number='5'/></td>
             </tr>
         <tr>
             <td><UserInRating name='User' number='6'/></td>
             </tr>
         <tr>
             <td><UserInRating name='User' number='7'/></td>
             </tr>
         <tr>
             <td><UserInRating name='User' number='8'/></td>
             </tr>
         <tr>
             <td><UserInRating name='User' number='9'/></td>
             </tr>
             <tr>
             <td><UserInRating name='User' number='9'/></td>
             </tr>
             <tr>
             <td><UserInRating name='User' number='9'/></td>
             </tr>
             <tr>
             <td><UserInRating name='User' number='9'/></td>
             </tr>
             <tr>
             <td><UserInRating name='User' number='9'/></td>
             </tr>
         </table>
         </ShadowScroll>
        </div>
    );
}
export default Rating;