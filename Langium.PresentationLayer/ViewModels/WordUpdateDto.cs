using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.PresentationLayer.ViewModels
{
    public class WordUpdateDto
    {
        public string Lexeme { get; set; }

        public string Transcription { get; set; }

        public string Translation { get; set; }

        public int CategoryId { get; set; }
    }
}
