﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class LexemeModel
    {
        public int Id { get; set; }

        public string Lexeme { get; set; }

        [JsonIgnore]
        public int WordId { get; set; }
        
        public WordModel Word { get; set; }
    }
}
