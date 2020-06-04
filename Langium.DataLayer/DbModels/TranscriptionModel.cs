using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer.DbModels
{
    public class TranscriptionModel
    {
        public int Id { get; set; }

        public string Transcription { get; set; }

        [JsonIgnore]
        public int WordId { get; set; }
        
        public WordModel Word { get; set; }
    }
}
