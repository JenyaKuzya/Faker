using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class LongGenerator : IValueGenerator
    {
        public object Generate()
        {
            long result;

            do
            {
                result = (long)Randomizer.random.Next();
            }
            while (result == default(long));

            return result;
        }
    }
}
