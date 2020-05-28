using Langium.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Langium.DataLayer.DataAccessObjects
{
    class WordDao
    {
        public async Task<WordModel> GetWordByIdAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var word = await context.Words
                    .Include(w => w.Lexeme)
                    .Include(w => w.Transcription)
                    .Include(w => w.Translations)
                    .FirstOrDefaultAsync(c => c.Id == id);

                    if (word == null)
                    {
                        return null;
                    }

                    return word;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<WordModel> AddWordAsync(WordModel word)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var added = await context.Words.AddAsync(word);
                    await context.SaveChangesAsync();
                    return added.Entity;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<WordModel> UpdateWordAsync(WordModel word)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    context.Entry(word).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return word;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return null;
                }
            }
        }

        public async Task<bool> RemoveWordAsync(int id)
        {
            using (var context = new LangiumDbContext())
            {
                try
                {
                    var entity = await context.Words.FindAsync(id);

                    if (entity == null)
                    {
                        return false;
                    }

                    context.Remove(entity);
                    await context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return false;
                }

            }
        }
    }
}
