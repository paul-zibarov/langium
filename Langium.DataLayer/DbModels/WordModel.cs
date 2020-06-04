using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class WordModel
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int LexemeId { get; set; }

        public LexemeModel Lexeme { get; set; }

        public TranslationModel Translation { get; set; }

        public TranscriptionModel Transcription { get; set; }

        
        public int CategoryId { get; set; }

        [JsonIgnore]
        public CategoryModel Category { get; set; }
    }
}
