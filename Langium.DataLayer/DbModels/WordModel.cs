using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class WordModel
    {
        public int Id { get; set; }

        public int LexemeId { get; set; }

        public LexemeModel Lexeme { get; set; }

        public List<TranslationModel> Translations { get; set; }

        public TranscriptionModel Transcription { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }
    }
}
