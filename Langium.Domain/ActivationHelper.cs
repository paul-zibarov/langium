using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.Domain
{
    public class ActivationHelper
    {
        private static readonly int _minValue = 100000;

        private static readonly int _maxValue = 999999;

        public static int GetActivationCode()
        {            
            return new Random().Next(_minValue, _maxValue);
        }
    }
}
