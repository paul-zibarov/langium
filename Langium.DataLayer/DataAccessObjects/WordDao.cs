using Langium.DataLayer.DbModels;
using Langium.PresentationLayer;
using Langium.PresentationLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    public class WordDao
    {
        public async Task<DataResult<WordModel>> GetWordByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var word = await context.Words
                        .Include(w => w.Lexeme)
                        .Include(w => w.Transcription)
                        .Include(w => w.Translation)
                    .FirstOrDefaultAsync(c => c.Id == id);

                    if (word == null)
                    {
                        return new DataResult<WordModel>(null, "WORD_NOT_EXISTS");
                    };

                    return new DataResult<WordModel>(word);
                }
                catch (Exception ex)
                {
                    return new DataResult<WordModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<IEnumerable<WordModel>>> GetCategoryWordsAsync(int categoryId)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var words = await context.Words
                        .Include(w => w.Lexeme)
                        .Include(w => w.Transcription)
                        .Include(w => w.Translation)
                    .Where(w => w.CategoryId == categoryId)
                    .ToListAsync();

                    return new DataResult<IEnumerable<WordModel>>(words);
                }
                catch (Exception ex)
                {
                    return new DataResult<IEnumerable<WordModel>>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<IEnumerable<WordModel>>> GetUserWordsAsync(int profileId)
        {
            CategoryDao categoryDao = new CategoryDao();

            try
            {
                List<WordModel> words = new List<WordModel>();

                var categories = categoryDao.GetUserCategoriesAsync(profileId).Result.Data.ToList();

                if (categories.Count() != 0 && categories != null)
                {
                    foreach (var c in categories)
                    {
                        if (c.Words.Count() != 0 && c.Words != null)
                        {
                            words.AddRange(c.Words);
                        }
                    }
                }

                return new DataResult<IEnumerable<WordModel>>(words);
            }
            catch (Exception ex)
            {
                return new DataResult<IEnumerable<WordModel>>(ex, ex.InnerException.Message);
            }
        }

        public async Task<DataResult<WordModel>> AddWordAsync(WordAddDto word)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var newWord = new WordModel()
                    {
                        Lexeme = new LexemeModel()
                        {
                            Lexeme = word.Lexeme
                        },
                        Transcription = new TranscriptionModel()
                        {
                            Transcription = word.Transcription
                        },
                        Translation = new TranslationModel()
                        {
                             Translation = word.Translation
                        },
                        CategoryId = word.CategoryId
                    };

                    CategoryDao categoryDao = new CategoryDao();

                    var sameWords = categoryDao.GetCategoryByIdAsync(word.CategoryId).Result.Data.Words.Where(w => w.Lexeme.Lexeme == word.Lexeme);

                    if (sameWords.Count() == 0)
                    {
                        var added = await context.Words.AddAsync(newWord);
                        await context.SaveChangesAsync();

                        return new DataResult<WordModel>(added.Entity);
                    }
                    else
                    {
                        return new DataResult<WordModel>(null, "WORD_WITH_SAME_LEXEM_AlREADY_EXISTS");
                    }
                }
                catch (Exception ex)
                {
                    return new DataResult<WordModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<WordModel>> UpdateWordAsync(WordModel word)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(word).State = EntityState.Modified;
                    context.Entry(word.Lexeme).State = EntityState.Modified;
                    context.Entry(word.Transcription).State = EntityState.Modified;
                    context.Entry(word.Translation).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    var updatedWord = context.Words.FirstOrDefault(w => w.Id == word.Id);

                    return new DataResult<WordModel>(updatedWord);
                }
                catch (Exception ex)
                {
                    return new DataResult<WordModel>(ex, ex.InnerException.Message);
                }
            }
        }

        public async Task<DataResult<bool>> RemoveWordAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Words.FindAsync(id);

                    if (entity == null)
                    {
                        return new DataResult<bool>(null, "WORD_NOT_EXISTS");
                    }

                    context.Remove(entity);

                    await context.SaveChangesAsync();

                    return new DataResult<bool>(true);
                }
                catch (Exception ex)
                {
                    return new DataResult<bool>(ex, ex.Message);
                }
            }
        }
    }
}
