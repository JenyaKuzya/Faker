using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class CharGenerator : IValueGenerator
    {
        public object Generate()
        {
            char result;

            do
            {
                result = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * Randomizer.random.NextDouble() + 65)));
            }
            while (result == default(char));

            return result;
        }
    }
}
