using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class ShortGenerator : IValueGenerator
    {
        public object Generate()
        {
            short result;

            do
            {
                result = (short)Randomizer.random.Next();
            }
            while (result == default(short));

            return result;
        }
    }
}
