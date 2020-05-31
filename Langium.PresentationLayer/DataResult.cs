using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.PresentationLayer
{
    public class DataResult<T>
    {
        public DataResult (T data)
        {
            Succeded = true;
            Data = data;
        }

        public DataResult(Exception ex, string errorMessage)
        {
            Succeded = false;
            Exception = ex;
            ErrorMessage = errorMessage;
        }

        public T Data { get; set; }

        public bool Succeded { get; set; }

        public string ErrorMessage { get; set; }

        [JsonIgnore]
        public Exception Exception { get; set; }
    }
}
