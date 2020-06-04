using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Langium.DataLayer.DataAccessObjects;
using Langium.DataLayer.DbModels;
using Langium.PresentationLayer;
using Langium.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Langium.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly WordDao _dao = new WordDao();

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<WordModel>>> Get(int id)
        {
            var result = await _dao.GetWordByIdAsync(id);

            if (result.Data != null && result.Succeded && result.Exception == null && string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else if (result.Exception == null)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET api/words/profile/{id}
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<IEnumerable<WordModel>>> GetProfileWords(int id)
        {
            var result = await _dao.GetUserWordsAsync(id);

            if (result.Data.Count() != 0 && result.Succeded && result.Exception == null && string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else if (result.Exception == null)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // GET api/words/category/{id}
        [HttpGet("category/{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryWords(int id)
        {
            var result = await _dao.GetCategoryWordsAsync(id);

            if (result.Data != null && result.Succeded && result.Exception == null && string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Ok(result);
            }
            else if (result.Exception == null)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // POST api/words/add
        [HttpPost("add")]
        public async Task<ActionResult<UserModel>> Post(WordAddDto word)
        {
            var result = await _dao.AddWordAsync(word);

            if (result.Data != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        // PUT api/words/{id}/edit
        [HttpPut("{id}/edit")]
        public async Task<ActionResult<UserModel>> Put(int id, WordUpdateDto wordData)
        {
            var word = _dao.GetWordByIdAsync(id).Result.Data;

            var categoryDao = new CategoryDao();

            var category = await categoryDao.GetCategoryByIdAsync(wordData.CategoryId);

            if (word != null)
            {
                if(category.Data != null)
                {
                    var categoryWords = _dao.GetCategoryWordsAsync(wordData.CategoryId).Result.Data.Where(w => w.Lexeme.Lexeme == wordData.Lexeme).ToList();

                    if (categoryWords.Count() != 0 || string.IsNullOrEmpty(wordData.Lexeme))
                    {
                        return BadRequest(new DataResult<WordModel>(null, "WORD_WITH_SAME_LEXEME_AlREADY_EXISTS_IN_THIS_CATEGORY"));
                    }
                    else
                    {
                        word.Lexeme.Lexeme = wordData.Lexeme;
                        word.Transcription.Transcription = wordData.Transcription;
                        word.Translation.Translation = wordData.Translation;
                        word.CategoryId = wordData.CategoryId;
                        var result = await _dao.UpdateWordAsync(word);

                        return Ok(result);
                    }
                }

                return BadRequest(new DataResult<CategoryModel>(null, "CATEGORY_NOT_EXISTS"));
            }

            return NotFound(new DataResult<CategoryModel>(null, "WORD_NOT_EXISTS"));
        }

        // DELETE api/words/{id}/delete
        [HttpDelete("{id}/delete")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _dao.RemoveWordAsync(id);

            if (result.Succeded)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
